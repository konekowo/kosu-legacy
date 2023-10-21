﻿using Cysharp.Threading.Tasks.Internal;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<IList<TSource>> Buffer<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, int count)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            if (count <= 0) throw Error.ArgumentOutOfRange(nameof(count));

            return new Buffer<TSource>(source, count);
        }

        public static IUniTaskAsyncEnumerable<IList<TSource>> Buffer<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, int count, int skip)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            if (count <= 0) throw Error.ArgumentOutOfRange(nameof(count));
            if (skip <= 0) throw Error.ArgumentOutOfRange(nameof(skip));

            return new BufferSkip<TSource>(source, count, skip);
        }
    }

    internal sealed class Buffer<TSource> : IUniTaskAsyncEnumerable<IList<TSource>>
    {
        private readonly IUniTaskAsyncEnumerable<TSource> source;
        private readonly int count;

        public Buffer(IUniTaskAsyncEnumerable<TSource> source, int count)
        {
            this.source = source;
            this.count = count;
        }

        public IUniTaskAsyncEnumerator<IList<TSource>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _Buffer(source, count, cancellationToken);
        }

        private sealed class _Buffer : MoveNextSource, IUniTaskAsyncEnumerator<IList<TSource>>
        {
            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;

            private readonly IUniTaskAsyncEnumerable<TSource> source;
            private readonly int count;
            private CancellationToken cancellationToken;

            private IUniTaskAsyncEnumerator<TSource> enumerator;
            private UniTask<bool>.Awaiter awaiter;
            private bool continueNext;

            private bool completed;
            private List<TSource> buffer;

            public _Buffer(IUniTaskAsyncEnumerable<TSource> source, int count, CancellationToken cancellationToken)
            {
                this.source = source;
                this.count = count;
                this.cancellationToken = cancellationToken;

                TaskTracker.TrackActiveTask(this, 3);
            }

            public IList<TSource> Current { get; private set; }

            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (enumerator == null)
                {
                    enumerator = source.GetAsyncEnumerator(cancellationToken);
                    buffer = new List<TSource>(count);
                }

                completionSource.Reset();
                SourceMoveNext();
                return new UniTask<bool>(this, completionSource.Version);
            }

            private void SourceMoveNext()
            {
                if (completed)
                {
                    if (buffer != null && buffer.Count > 0)
                    {
                        var ret = buffer;
                        buffer = null;
                        Current = ret;
                        completionSource.TrySetResult(true);
                        return;
                    }
                    else
                    {
                        completionSource.TrySetResult(false);
                        return;
                    }
                }

                try
                {
                    LOOP:
                    awaiter = enumerator.MoveNextAsync().GetAwaiter();
                    if (awaiter.IsCompleted)
                    {
                        continueNext = true;
                        MoveNextCore(this);
                        if (continueNext)
                        {
                            continueNext = false;
                            goto LOOP; // avoid recursive
                        }
                    }
                    else
                    {
                        awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);
                    }
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                }
            }


            private static void MoveNextCore(object state)
            {
                var self = (_Buffer)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                    {
                        self.buffer.Add(self.enumerator.Current);

                        if (self.buffer.Count == self.count)
                        {
                            self.Current = self.buffer;
                            self.buffer = new List<TSource>(self.count);
                            self.continueNext = false;
                            self.completionSource.TrySetResult(true);
                            return;
                        }
                        else
                        {
                            if (!self.continueNext) self.SourceMoveNext();
                        }
                    }
                    else
                    {
                        self.continueNext = false;
                        self.completed = true;
                        self.SourceMoveNext();
                    }
                }
                else
                {
                    self.continueNext = false;
                }
            }

            public UniTask DisposeAsync()
            {
                TaskTracker.RemoveTracking(this);
                if (enumerator != null) return enumerator.DisposeAsync();
                return default;
            }
        }
    }

    internal sealed class BufferSkip<TSource> : IUniTaskAsyncEnumerable<IList<TSource>>
    {
        private readonly IUniTaskAsyncEnumerable<TSource> source;
        private readonly int count;
        private readonly int skip;

        public BufferSkip(IUniTaskAsyncEnumerable<TSource> source, int count, int skip)
        {
            this.source = source;
            this.count = count;
            this.skip = skip;
        }

        public IUniTaskAsyncEnumerator<IList<TSource>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _BufferSkip(source, count, skip, cancellationToken);
        }

        private sealed class _BufferSkip : MoveNextSource, IUniTaskAsyncEnumerator<IList<TSource>>
        {
            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;

            private readonly IUniTaskAsyncEnumerable<TSource> source;
            private readonly int count;
            private readonly int skip;
            private CancellationToken cancellationToken;

            private IUniTaskAsyncEnumerator<TSource> enumerator;
            private UniTask<bool>.Awaiter awaiter;
            private bool continueNext;

            private bool completed;
            private Queue<List<TSource>> buffers;
            private int index = 0;

            public _BufferSkip(IUniTaskAsyncEnumerable<TSource> source, int count, int skip,
                CancellationToken cancellationToken)
            {
                this.source = source;
                this.count = count;
                this.skip = skip;
                this.cancellationToken = cancellationToken;
                TaskTracker.TrackActiveTask(this, 3);
            }

            public IList<TSource> Current { get; private set; }

            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (enumerator == null)
                {
                    enumerator = source.GetAsyncEnumerator(cancellationToken);
                    buffers = new Queue<List<TSource>>();
                }

                completionSource.Reset();
                SourceMoveNext();
                return new UniTask<bool>(this, completionSource.Version);
            }

            private void SourceMoveNext()
            {
                if (completed)
                {
                    if (buffers.Count > 0)
                    {
                        Current = buffers.Dequeue();
                        completionSource.TrySetResult(true);
                        return;
                    }
                    else
                    {
                        completionSource.TrySetResult(false);
                        return;
                    }
                }

                try
                {
                    LOOP:
                    awaiter = enumerator.MoveNextAsync().GetAwaiter();
                    if (awaiter.IsCompleted)
                    {
                        continueNext = true;
                        MoveNextCore(this);
                        if (continueNext)
                        {
                            continueNext = false;
                            goto LOOP; // avoid recursive
                        }
                    }
                    else
                    {
                        awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);
                    }
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                }
            }


            private static void MoveNextCore(object state)
            {
                var self = (_BufferSkip)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                    {
                        if (self.index++ % self.skip == 0) self.buffers.Enqueue(new List<TSource>(self.count));

                        var item = self.enumerator.Current;
                        foreach (var buffer in self.buffers) buffer.Add(item);

                        if (self.buffers.Count > 0 && self.buffers.Peek().Count == self.count)
                        {
                            self.Current = self.buffers.Dequeue();
                            self.continueNext = false;
                            self.completionSource.TrySetResult(true);
                            return;
                        }
                        else
                        {
                            if (!self.continueNext) self.SourceMoveNext();
                        }
                    }
                    else
                    {
                        self.continueNext = false;
                        self.completed = true;
                        self.SourceMoveNext();
                    }
                }
                else
                {
                    self.continueNext = false;
                }
            }

            public UniTask DisposeAsync()
            {
                TaskTracker.RemoveTracking(this);
                if (enumerator != null) return enumerator.DisposeAsync();
                return default;
            }
        }
    }
}