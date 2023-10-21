using System;
using System.Threading;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static UniTask<int> SumAsync(this IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<int> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<int> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<int> SumAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> SumAsync(this IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<long> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> SumAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> SumAsync(this IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<float> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> SumAsync(this IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<double> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> SumAsync(this IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<decimal> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> SumAsync(this IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<int?> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> SumAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> SumAsync(this IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<long?> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> SumAsync(this IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<float?> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> SumAsync(this IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<double?> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> SumAsync(this IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Sum.SumAsync(source, cancellationToken);
        }

        public static UniTask<decimal?> SumAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> SumAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> SumAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Sum.SumAwaitWithCancellationAsync(source, selector, cancellationToken);
        }
    }

    internal static class Sum
    {
        public static async UniTask<int> SumAsync(IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken)
        {
            int sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current;
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            int sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            int sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int> SumAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            int sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current, cancellationToken);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long> SumAsync(IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken)
        {
            long sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current;
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            long sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken)
        {
            long sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long>> selector,
            CancellationToken cancellationToken)
        {
            long sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current, cancellationToken);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float> SumAsync(IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken)
        {
            float sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current;
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            float sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken)
        {
            float sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken)
        {
            float sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current, cancellationToken);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double> SumAsync(IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken)
        {
            double sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current;
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            double sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken)
        {
            double sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken)
        {
            double sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current, cancellationToken);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal> SumAsync(IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken)
        {
            decimal sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current;
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            decimal sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken)
        {
            decimal sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken)
        {
            decimal sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += await selector(e.Current, cancellationToken);
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int?> SumAsync(IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken)
        {
            int? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current.GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int?> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            int? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int?> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken)
        {
            int? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += (await selector(e.Current)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<int?> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int?>> selector,
            CancellationToken cancellationToken)
        {
            int? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    sum += (await selector(e.Current, cancellationToken)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long?> SumAsync(IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken)
        {
            long? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current.GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long?> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            long? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long?> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken)
        {
            long? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += (await selector(e.Current)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<long?> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken)
        {
            long? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    sum += (await selector(e.Current, cancellationToken)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float?> SumAsync(IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken)
        {
            float? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current.GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float?> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            float? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float?> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken)
        {
            float? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += (await selector(e.Current)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<float?> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken)
        {
            float? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    sum += (await selector(e.Current, cancellationToken)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double?> SumAsync(IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken)
        {
            double? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current.GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double?> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            double? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double?> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken)
        {
            double? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += (await selector(e.Current)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<double?> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken)
        {
            double? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    sum += (await selector(e.Current, cancellationToken)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal?> SumAsync(IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken)
        {
            decimal? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += e.Current.GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal?> SumAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            decimal? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += selector(e.Current).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal?> SumAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken)
        {
            decimal? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync()) sum += (await selector(e.Current)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }

        public static async UniTask<decimal?> SumAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken)
        {
            decimal? sum = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    sum += (await selector(e.Current, cancellationToken)).GetValueOrDefault();
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum;
        }
    }
}