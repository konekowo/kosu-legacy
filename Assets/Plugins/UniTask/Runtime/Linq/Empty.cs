using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<T> Empty<T>()
        {
            return Linq.Empty<T>.Instance;
        }
    }

    internal class Empty<T> : IUniTaskAsyncEnumerable<T>
    {
        public static readonly IUniTaskAsyncEnumerable<T> Instance = new Empty<T>();

        private Empty()
        {
        }

        public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return _Empty.Instance;
        }

        private class _Empty : IUniTaskAsyncEnumerator<T>
        {
            public static readonly IUniTaskAsyncEnumerator<T> Instance = new _Empty();

            private _Empty()
            {
            }

            public T Current => default;

            public UniTask<bool> MoveNextAsync()
            {
                return CompletedTasks.False;
            }

            public UniTask DisposeAsync()
            {
                return default;
            }
        }
    }
}