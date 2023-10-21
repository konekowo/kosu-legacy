using Cysharp.Threading.Tasks.Internal;
using System;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<TSource> Append<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            TSource element)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return new AppendPrepend<TSource>(source, element, true);
        }

        public static IUniTaskAsyncEnumerable<TSource> Prepend<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            TSource element)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return new AppendPrepend<TSource>(source, element, false);
        }
    }

    internal sealed class AppendPrepend<TSource> : IUniTaskAsyncEnumerable<TSource>
    {
        private readonly IUniTaskAsyncEnumerable<TSource> source;
        private readonly TSource element;
        private readonly bool append; // or prepend

        public AppendPrepend(IUniTaskAsyncEnumerable<TSource> source, TSource element, bool append)
        {
            this.source = source;
            this.element = element;
            this.append = append;
        }

        public IUniTaskAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _AppendPrepend(source, element, append, cancellationToken);
        }

        private sealed class _AppendPrepend : MoveNextSource, IUniTaskAsyncEnumerator<TSource>
        {
            private enum State : byte
            {
                None,
                RequirePrepend,
                RequireAppend,
                Completed
            }

            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;

            private readonly IUniTaskAsyncEnumerable<TSource> source;
            private readonly TSource element;
            private CancellationToken cancellationToken;

            private State state;
            private IUniTaskAsyncEnumerator<TSource> enumerator;
            private UniTask<bool>.Awaiter awaiter;

            public _AppendPrepend(IUniTaskAsyncEnumerable<TSource> source, TSource element, bool append,
                CancellationToken cancellationToken)
            {
                this.source = source;
                this.element = element;
                state = append ? State.RequireAppend : State.RequirePrepend;
                this.cancellationToken = cancellationToken;

                TaskTracker.TrackActiveTask(this, 3);
            }

            public TSource Current { get; private set; }


            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();
                completionSource.Reset();

                if (enumerator == null)
                {
                    if (state == State.RequirePrepend)
                    {
                        Current = element;
                        state = State.None;
                        return CompletedTasks.True;
                    }

                    enumerator = source.GetAsyncEnumerator(cancellationToken);
                }

                if (state == State.Completed) return CompletedTasks.False;

                awaiter = enumerator.MoveNextAsync().GetAwaiter();

                if (awaiter.IsCompleted)
                    MoveNextCoreDelegate(this);
                else
                    awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);

                return new UniTask<bool>(this, completionSource.Version);
            }

            private static void MoveNextCore(object state)
            {
                var self = (_AppendPrepend)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                    {
                        self.Current = self.enumerator.Current;
                        self.completionSource.TrySetResult(true);
                    }
                    else
                    {
                        if (self.state == State.RequireAppend)
                        {
                            self.state = State.Completed;
                            self.Current = self.element;
                            self.completionSource.TrySetResult(true);
                        }
                        else
                        {
                            self.state = State.Completed;
                            self.completionSource.TrySetResult(false);
                        }
                    }
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