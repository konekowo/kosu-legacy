using System;
using System.Threading;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static UniTask<double> AverageAsync(this IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<double> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAsync(this IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<double> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> AverageAsync(this IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<float> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAsync(this IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<double> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> AverageAsync(this IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<decimal> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAsync(this IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<double?> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAsync(this IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<double?> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> AverageAsync(this IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<float?> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAsync(this IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<double?> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> AverageAsync(this IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Average.AverageAsync(source, cancellationToken);
        }

        public static UniTask<decimal?> AverageAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> AverageAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> AverageAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Average.AverageAwaitWithCancellationAsync(source, selector, cancellationToken);
        }
    }

    internal static class Average
    {
        public static async UniTask<double> AverageAsync(IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += e.Current;
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current, cancellationToken);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAsync(IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            long sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += e.Current;
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            long sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            long sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            long sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current, cancellationToken);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<float> AverageAsync(IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            float sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += e.Current;
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<float> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            float sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<float> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            float sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<float> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            float sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current, cancellationToken);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<double> AverageAsync(IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            double sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += e.Current;
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            double sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            double sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            double sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current, cancellationToken);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal> AverageAsync(IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            decimal sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += e.Current;
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            decimal sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            decimal sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            decimal sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                    checked
                    {
                        sum += await selector(e.Current, cancellationToken);
                        count++;
                    }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double?> AverageAsync(IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            int? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = e.Current;
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            int? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            int? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int?>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            int? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current, cancellationToken);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAsync(IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            long? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = e.Current;
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            long? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            long? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            long? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current, cancellationToken);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (double)sum / count;
        }

        public static async UniTask<float?> AverageAsync(IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            float? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = e.Current;
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<float?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            float? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<float?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            float? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<float?> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            float? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current, cancellationToken);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return (float)(sum / count);
        }

        public static async UniTask<double?> AverageAsync(IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            double? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = e.Current;
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            double? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            double? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<double?> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            double? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current, cancellationToken);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal?> AverageAsync(IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken)
        {
            long count = 0;
            decimal? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = e.Current;
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal?> AverageAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            decimal? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal?> AverageAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken)
        {
            long count = 0;
            decimal? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }

        public static async UniTask<decimal?> AverageAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken)
        {
            long count = 0;
            decimal? sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    var v = await selector(e.Current, cancellationToken);
                    if (v.HasValue)
                        checked
                        {
                            sum += v.Value;
                            count++;
                        }
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return sum / count;
        }
    }
}