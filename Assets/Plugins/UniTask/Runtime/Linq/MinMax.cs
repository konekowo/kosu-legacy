using System;
using System.Threading;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static UniTask<int> MinAsync(this IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<int> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<int> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<int> MinAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> MinAsync(this IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<long> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> MinAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> MinAsync(this IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<float> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> MinAsync(this IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<double> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> MinAsync(this IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<decimal> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> MinAsync(this IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<int?> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> MinAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> MinAsync(this IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<long?> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> MinAsync(this IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<float?> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> MinAsync(this IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<double?> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> MinAsync(this IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Min.MinAsync(source, cancellationToken);
        }

        public static UniTask<decimal?> MinAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> MinAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> MinAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Min.MinAwaitWithCancellationAsync(source, selector, cancellationToken);
        }
    }

    internal static partial class Min
    {
        public static async UniTask<int> MinAsync(IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int> MinAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MinAsync(IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long>> selector,
            CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MinAsync(IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MinAsync(IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MinAsync(IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MinAsync(IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int?>> selector,
            CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MinAsync(IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MinAsync(IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MinAsync(IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MinAsync(IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MinAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MinAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MinAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value > x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }
    }

    public static partial class UniTaskAsyncEnumerable
    {
        public static UniTask<int> MaxAsync(this IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<int> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<int> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<int> MaxAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> MaxAsync(this IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<long> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<long> MaxAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<long>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> MaxAsync(this IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<float> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> MaxAsync(this IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<double> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> MaxAsync(this IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<decimal> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> MaxAsync(this IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<int?> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<int?> MaxAwaitWithCancellationAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> MaxAsync(this IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<long?> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<long?> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> MaxAsync(this IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<float?> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<float?> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> MaxAsync(this IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<double?> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<double?> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> MaxAsync(this IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));

            return Max.MaxAsync(source, cancellationToken);
        }

        public static UniTask<decimal?> MaxAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> MaxAwaitAsync<TSource>(this IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitAsync(source, selector, cancellationToken);
        }

        public static UniTask<decimal?> MaxAwaitWithCancellationAsync<TSource>(
            this IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentNullException(source, nameof(source));
            Error.ThrowArgumentNullException(source, nameof(selector));

            return Max.MaxAwaitWithCancellationAsync(source, selector, cancellationToken);
        }
    }

    internal static partial class Max
    {
        public static async UniTask<int> MaxAsync(IUniTaskAsyncEnumerable<int> source,
            CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int> MaxAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, CancellationToken, UniTask<int>> selector, CancellationToken cancellationToken)
        {
            int value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MaxAsync(IUniTaskAsyncEnumerable<long> source,
            CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long>> selector, CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long>> selector,
            CancellationToken cancellationToken)
        {
            long value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MaxAsync(IUniTaskAsyncEnumerable<float> source,
            CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float>> selector, CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float>> selector,
            CancellationToken cancellationToken)
        {
            float value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MaxAsync(IUniTaskAsyncEnumerable<double> source,
            CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double>> selector, CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double>> selector,
            CancellationToken cancellationToken)
        {
            double value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MaxAsync(IUniTaskAsyncEnumerable<decimal> source,
            CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal>> selector, CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal>> selector,
            CancellationToken cancellationToken)
        {
            decimal value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);

                    goto NEXT_LOOP;
                }

                throw Error.NoElements();

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MaxAsync(IUniTaskAsyncEnumerable<int?> source,
            CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<int?>> selector, CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<int?> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<int?>> selector,
            CancellationToken cancellationToken)
        {
            int? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MaxAsync(IUniTaskAsyncEnumerable<long?> source,
            CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<long?>> selector, CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<long?> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<long?>> selector,
            CancellationToken cancellationToken)
        {
            long? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MaxAsync(IUniTaskAsyncEnumerable<float?> source,
            CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<float?>> selector, CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<float?> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<float?>> selector,
            CancellationToken cancellationToken)
        {
            float? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MaxAsync(IUniTaskAsyncEnumerable<double?> source,
            CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<double?>> selector, CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<double?> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<double?>> selector,
            CancellationToken cancellationToken)
        {
            double? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MaxAsync(IUniTaskAsyncEnumerable<decimal?> source,
            CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = e.Current;
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = e.Current;
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MaxAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MaxAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source,
            Func<TSource, UniTask<decimal?>> selector, CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }

        public static async UniTask<decimal?> MaxAwaitWithCancellationAsync<TSource>(
            IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<decimal?>> selector,
            CancellationToken cancellationToken)
        {
            decimal? value = default;

            var e = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await e.MoveNextAsync())
                {
                    value = await selector(e.Current, cancellationToken);
                    if (value == null) continue;

                    goto NEXT_LOOP;
                }

                return default;

                NEXT_LOOP:

                while (await e.MoveNextAsync())
                {
                    var x = await selector(e.Current, cancellationToken);
                    if (x == null) continue;
                    if (value < x) value = x;
                }
            }
            finally
            {
                if (e != null) await e.DisposeAsync();
            }

            return value;
        }
    }
}