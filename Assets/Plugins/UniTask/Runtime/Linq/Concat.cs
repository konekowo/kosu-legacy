using Cysharp.Threading.Tasks.Internal;
using System;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<TSource> Concat<TSource>(this IUniTaskAsyncEnumerable<TSource> first,
            IUniTaskAsyncEnumerable<TSource> second)
        {
            Error.ThrowArgumentNullException(first, nameof(first));
            Error.ThrowArgumentNullException(second, nameof(second));

            return new Concat<TSource>(first, second);
        }
    }

    internal sealed class Concat<TSource> : IUniTaskAsyncEnumerable<TSource>
    {
        private readonly IUniTaskAsyncEnumerable<TSource> first;
        private readonly IUniTaskAsyncEnumerable<TSource> second;

        public Concat(IUniTaskAsyncEnumerable<TSource> first, IUniTaskAsyncEnumerable<TSource> second)
        {
            this.first = first;
            this.second = second;
        }

        public IUniTaskAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _Concat(first, second, cancellationToken);
        }

        private sealed class _Concat : MoveNextSource, IUniTaskAsyncEnumerator<TSource>
        {
            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;

            private enum IteratingState
            {
                IteratingFirst,
                IteratingSecond,
                Complete
            }

            private readonly IUniTaskAsyncEnumerable<TSource> first;
            private readonly IUniTaskAsyncEnumerable<TSource> second;
            private CancellationToken cancellationToken;

            private IteratingState iteratingState;

            private IUniTaskAsyncEnumerator<TSource> enumerator;
            private UniTask<bool>.Awaiter awaiter;

            public _Concat(IUniTaskAsyncEnumerable<TSource> first, IUniTaskAsyncEnumerable<TSource> second,
                CancellationToken cancellationToken)
            {
                this.first = first;
                this.second = second;
                this.cancellationToken = cancellationToken;
                iteratingState = IteratingState.IteratingFirst;
                TaskTracker.TrackActiveTask(this, 3);
            }

            public TSource Current { get; private set; }

            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (iteratingState == IteratingState.Complete) return CompletedTasks.False;

                completionSource.Reset();
                StartIterate();
                return new UniTask<bool>(this, completionSource.Version);
            }

            private void StartIterate()
            {
                if (enumerator == null)
                {
                    if (iteratingState == IteratingState.IteratingFirst)
                        enumerator = first.GetAsyncEnumerator(cancellationToken);
                    else if (iteratingState == IteratingState.IteratingSecond)
                        enumerator = second.GetAsyncEnumerator(cancellationToken);
                }

                try
                {
                    awaiter = enumerator.MoveNextAsync().GetAwaiter();
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                    return;
                }

                if (awaiter.IsCompleted)
                    MoveNextCoreDelegate(this);
                else
                    awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);
            }

            private static void MoveNextCore(object state)
            {
                var self = (_Concat)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                    {
                        self.Current = self.enumerator.Current;
                        self.completionSource.TrySetResult(true);
                    }
                    else
                    {
                        if (self.iteratingState == IteratingState.IteratingFirst)
                        {
                            self.RunSecondAfterDisposeAsync().Forget();
                            return;
                        }

                        self.iteratingState = IteratingState.Complete;
                        self.completionSource.TrySetResult(false);
                    }
                }
            }

            private async UniTaskVoid RunSecondAfterDisposeAsync()
            {
                try
                {
                    await enumerator.DisposeAsync();
                    enumerator = null;
                    awaiter = default;
                    iteratingState = IteratingState.IteratingSecond;
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                }

                StartIterate();
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