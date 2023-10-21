using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<T> Never<T>()
        {
            return Linq.Never<T>.Instance;
        }
    }

    internal class Never<T> : IUniTaskAsyncEnumerable<T>
    {
        public static readonly IUniTaskAsyncEnumerable<T> Instance = new Never<T>();

        private Never()
        {
        }

        public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _Never(cancellationToken);
        }

        private class _Never : IUniTaskAsyncEnumerator<T>
        {
            private CancellationToken cancellationToken;

            public _Never(CancellationToken cancellationToken)
            {
                this.cancellationToken = cancellationToken;
            }

            public T Current => default;

            public UniTask<bool> MoveNextAsync()
            {
                var tcs = new UniTaskCompletionSource<bool>();

                cancellationToken.Register(state =>
                {
                    var task = (UniTaskCompletionSource<bool>)state;
                    task.TrySetCanceled(cancellationToken);
                }, tcs);

                return tcs.Task;
            }

            public UniTask DisposeAsync()
            {
                return default;
            }
        }
    }
}