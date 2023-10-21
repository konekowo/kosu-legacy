﻿using Cysharp.Threading.Tasks.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            Error.ThrowArgumentNullException(outer, nameof(outer));
            Error.ThrowArgumentNullException(inner, nameof(inner));
            Error.ThrowArgumentNullException(outerKeySelector, nameof(outerKeySelector));
            Error.ThrowArgumentNullException(innerKeySelector, nameof(innerKeySelector));
            Error.ThrowArgumentNullException(resultSelector, nameof(resultSelector));

            return new GroupJoin<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector,
                resultSelector, EqualityComparer<TKey>.Default);
        }

        public static IUniTaskAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            Error.ThrowArgumentNullException(outer, nameof(outer));
            Error.ThrowArgumentNullException(inner, nameof(inner));
            Error.ThrowArgumentNullException(outerKeySelector, nameof(outerKeySelector));
            Error.ThrowArgumentNullException(innerKeySelector, nameof(innerKeySelector));
            Error.ThrowArgumentNullException(resultSelector, nameof(resultSelector));
            Error.ThrowArgumentNullException(comparer, nameof(comparer));

            return new GroupJoin<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector,
                resultSelector, comparer);
        }

        public static IUniTaskAsyncEnumerable<TResult> GroupJoinAwait<TOuter, TInner, TKey, TResult>(
            this IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, UniTask<TKey>> outerKeySelector, Func<TInner, UniTask<TKey>> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, UniTask<TResult>> resultSelector)
        {
            Error.ThrowArgumentNullException(outer, nameof(outer));
            Error.ThrowArgumentNullException(inner, nameof(inner));
            Error.ThrowArgumentNullException(outerKeySelector, nameof(outerKeySelector));
            Error.ThrowArgumentNullException(innerKeySelector, nameof(innerKeySelector));
            Error.ThrowArgumentNullException(resultSelector, nameof(resultSelector));

            return new GroupJoinAwait<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector,
                resultSelector, EqualityComparer<TKey>.Default);
        }

        public static IUniTaskAsyncEnumerable<TResult> GroupJoinAwait<TOuter, TInner, TKey, TResult>(
            this IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, UniTask<TKey>> outerKeySelector, Func<TInner, UniTask<TKey>> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, UniTask<TResult>> resultSelector, IEqualityComparer<TKey> comparer)
        {
            Error.ThrowArgumentNullException(outer, nameof(outer));
            Error.ThrowArgumentNullException(inner, nameof(inner));
            Error.ThrowArgumentNullException(outerKeySelector, nameof(outerKeySelector));
            Error.ThrowArgumentNullException(innerKeySelector, nameof(innerKeySelector));
            Error.ThrowArgumentNullException(resultSelector, nameof(resultSelector));
            Error.ThrowArgumentNullException(comparer, nameof(comparer));

            return new GroupJoinAwait<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector,
                resultSelector, comparer);
        }

        public static IUniTaskAsyncEnumerable<TResult> GroupJoinAwaitWithCancellation<TOuter, TInner, TKey, TResult>(
            this IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, CancellationToken, UniTask<TKey>> outerKeySelector,
            Func<TInner, CancellationToken, UniTask<TKey>> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, CancellationToken, UniTask<TResult>> resultSelector)
        {
            Error.ThrowArgumentNullException(outer, nameof(outer));
            Error.ThrowArgumentNullException(inner, nameof(inner));
            Error.ThrowArgumentNullException(outerKeySelector, nameof(outerKeySelector));
            Error.ThrowArgumentNullException(innerKeySelector, nameof(innerKeySelector));
            Error.ThrowArgumentNullException(resultSelector, nameof(resultSelector));

            return new GroupJoinAwaitWithCancellation<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector,
                innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        public static IUniTaskAsyncEnumerable<TResult> GroupJoinAwaitWithCancellation<TOuter, TInner, TKey, TResult>(
            this IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, CancellationToken, UniTask<TKey>> outerKeySelector,
            Func<TInner, CancellationToken, UniTask<TKey>> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, CancellationToken, UniTask<TResult>> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Error.ThrowArgumentNullException(outer, nameof(outer));
            Error.ThrowArgumentNullException(inner, nameof(inner));
            Error.ThrowArgumentNullException(outerKeySelector, nameof(outerKeySelector));
            Error.ThrowArgumentNullException(innerKeySelector, nameof(innerKeySelector));
            Error.ThrowArgumentNullException(resultSelector, nameof(resultSelector));
            Error.ThrowArgumentNullException(comparer, nameof(comparer));

            return new GroupJoinAwaitWithCancellation<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector,
                innerKeySelector, resultSelector, comparer);
        }
    }

    internal sealed class GroupJoin<TOuter, TInner, TKey, TResult> : IUniTaskAsyncEnumerable<TResult>
    {
        private readonly IUniTaskAsyncEnumerable<TOuter> outer;
        private readonly IUniTaskAsyncEnumerable<TInner> inner;
        private readonly Func<TOuter, TKey> outerKeySelector;
        private readonly Func<TInner, TKey> innerKeySelector;
        private readonly Func<TOuter, IEnumerable<TInner>, TResult> resultSelector;
        private readonly IEqualityComparer<TKey> comparer;

        public GroupJoin(IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            this.outer = outer;
            this.inner = inner;
            this.outerKeySelector = outerKeySelector;
            this.innerKeySelector = innerKeySelector;
            this.resultSelector = resultSelector;
            this.comparer = comparer;
        }

        public IUniTaskAsyncEnumerator<TResult> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer,
                cancellationToken);
        }

        private sealed class _GroupJoin : MoveNextSource, IUniTaskAsyncEnumerator<TResult>
        {
            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;

            private readonly IUniTaskAsyncEnumerable<TOuter> outer;
            private readonly IUniTaskAsyncEnumerable<TInner> inner;
            private readonly Func<TOuter, TKey> outerKeySelector;
            private readonly Func<TInner, TKey> innerKeySelector;
            private readonly Func<TOuter, IEnumerable<TInner>, TResult> resultSelector;
            private readonly IEqualityComparer<TKey> comparer;
            private CancellationToken cancellationToken;

            private ILookup<TKey, TInner> lookup;
            private IUniTaskAsyncEnumerator<TOuter> enumerator;
            private UniTask<bool>.Awaiter awaiter;


            public _GroupJoin(IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
                Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
                Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer,
                CancellationToken cancellationToken)
            {
                this.outer = outer;
                this.inner = inner;
                this.outerKeySelector = outerKeySelector;
                this.innerKeySelector = innerKeySelector;
                this.resultSelector = resultSelector;
                this.comparer = comparer;
                this.cancellationToken = cancellationToken;
                TaskTracker.TrackActiveTask(this, 3);
            }

            public TResult Current { get; private set; }

            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();
                completionSource.Reset();

                if (lookup == null)
                    CreateLookup().Forget();
                else
                    SourceMoveNext();
                return new UniTask<bool>(this, completionSource.Version);
            }

            private async UniTaskVoid CreateLookup()
            {
                try
                {
                    lookup = await inner.ToLookupAsync(innerKeySelector, comparer, cancellationToken);
                    enumerator = outer.GetAsyncEnumerator(cancellationToken);
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                    return;
                }

                SourceMoveNext();
            }

            private void SourceMoveNext()
            {
                try
                {
                    awaiter = enumerator.MoveNextAsync().GetAwaiter();
                    if (awaiter.IsCompleted)
                        MoveNextCore(this);
                    else
                        awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                }
            }

            private static void MoveNextCore(object state)
            {
                var self = (_GroupJoin)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                    {
                        var outer = self.enumerator.Current;
                        var key = self.outerKeySelector(outer);
                        var values = self.lookup[key];

                        self.Current = self.resultSelector(outer, values);
                        self.completionSource.TrySetResult(true);
                    }
                    else
                    {
                        self.completionSource.TrySetResult(false);
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

    internal sealed class GroupJoinAwait<TOuter, TInner, TKey, TResult> : IUniTaskAsyncEnumerable<TResult>
    {
        private readonly IUniTaskAsyncEnumerable<TOuter> outer;
        private readonly IUniTaskAsyncEnumerable<TInner> inner;
        private readonly Func<TOuter, UniTask<TKey>> outerKeySelector;
        private readonly Func<TInner, UniTask<TKey>> innerKeySelector;
        private readonly Func<TOuter, IEnumerable<TInner>, UniTask<TResult>> resultSelector;
        private readonly IEqualityComparer<TKey> comparer;

        public GroupJoinAwait(IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
            Func<TOuter, UniTask<TKey>> outerKeySelector, Func<TInner, UniTask<TKey>> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, UniTask<TResult>> resultSelector, IEqualityComparer<TKey> comparer)
        {
            this.outer = outer;
            this.inner = inner;
            this.outerKeySelector = outerKeySelector;
            this.innerKeySelector = innerKeySelector;
            this.resultSelector = resultSelector;
            this.comparer = comparer;
        }

        public IUniTaskAsyncEnumerator<TResult> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _GroupJoinAwait(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer,
                cancellationToken);
        }

        private sealed class _GroupJoinAwait : MoveNextSource, IUniTaskAsyncEnumerator<TResult>
        {
            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;
            private static readonly Action<object> ResultSelectCoreDelegate = ResultSelectCore;
            private static readonly Action<object> OuterKeySelectCoreDelegate = OuterKeySelectCore;

            private readonly IUniTaskAsyncEnumerable<TOuter> outer;
            private readonly IUniTaskAsyncEnumerable<TInner> inner;
            private readonly Func<TOuter, UniTask<TKey>> outerKeySelector;
            private readonly Func<TInner, UniTask<TKey>> innerKeySelector;
            private readonly Func<TOuter, IEnumerable<TInner>, UniTask<TResult>> resultSelector;
            private readonly IEqualityComparer<TKey> comparer;
            private CancellationToken cancellationToken;

            private ILookup<TKey, TInner> lookup;
            private IUniTaskAsyncEnumerator<TOuter> enumerator;
            private TOuter outerValue;
            private UniTask<bool>.Awaiter awaiter;
            private UniTask<TKey>.Awaiter outerKeyAwaiter;
            private UniTask<TResult>.Awaiter resultAwaiter;


            public _GroupJoinAwait(IUniTaskAsyncEnumerable<TOuter> outer, IUniTaskAsyncEnumerable<TInner> inner,
                Func<TOuter, UniTask<TKey>> outerKeySelector, Func<TInner, UniTask<TKey>> innerKeySelector,
                Func<TOuter, IEnumerable<TInner>, UniTask<TResult>> resultSelector, IEqualityComparer<TKey> comparer,
                CancellationToken cancellationToken)
            {
                this.outer = outer;
                this.inner = inner;
                this.outerKeySelector = outerKeySelector;
                this.innerKeySelector = innerKeySelector;
                this.resultSelector = resultSelector;
                this.comparer = comparer;
                this.cancellationToken = cancellationToken;
                TaskTracker.TrackActiveTask(this, 3);
            }

            public TResult Current { get; private set; }

            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();
                completionSource.Reset();

                if (lookup == null)
                    CreateLookup().Forget();
                else
                    SourceMoveNext();
                return new UniTask<bool>(this, completionSource.Version);
            }

            private async UniTaskVoid CreateLookup()
            {
                try
                {
                    lookup = await inner.ToLookupAwaitAsync(innerKeySelector, comparer, cancellationToken);
                    enumerator = outer.GetAsyncEnumerator(cancellationToken);
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                    return;
                }

                SourceMoveNext();
            }

            private void SourceMoveNext()
            {
                try
                {
                    awaiter = enumerator.MoveNextAsync().GetAwaiter();
                    if (awaiter.IsCompleted)
                        MoveNextCore(this);
                    else
                        awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                }
            }

            private static void MoveNextCore(object state)
            {
                var self = (_GroupJoinAwait)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                        try
                        {
                            self.outerValue = self.enumerator.Current;
                            self.outerKeyAwaiter = self.outerKeySelector(self.outerValue).GetAwaiter();
                            if (self.outerKeyAwaiter.IsCompleted)
                                OuterKeySelectCore(self);
                            else
                                self.outerKeyAwaiter.SourceOnCompleted(OuterKeySelectCoreDelegate, self);
                        }
                        catch (Exception ex)
                        {
                            self.completionSource.TrySetException(ex);
                        }
                    else
                        self.completionSource.TrySetResult(false);
                }
            }

            private static void OuterKeySelectCore(object state)
            {
                var self = (_GroupJoinAwait)state;

                if (self.TryGetResult(self.outerKeyAwaiter, out var result))
                    try
                    {
                        var values = self.lookup[result];
                        self.resultAwaiter = self.resultSelector(self.outerValue, values).GetAwaiter();
                        if (self.resultAwaiter.IsCompleted)
                            ResultSelectCore(self);
                        else
                            self.resultAwaiter.SourceOnCompleted(ResultSelectCoreDelegate, self);
                    }
                    catch (Exception ex)
                    {
                        self.completionSource.TrySetException(ex);
                    }
            }

            private static void ResultSelectCore(object state)
            {
                var self = (_GroupJoinAwait)state;

                if (self.TryGetResult(self.resultAwaiter, out var result))
                {
                    self.Current = result;
                    self.completionSource.TrySetResult(true);
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

    internal sealed class
        GroupJoinAwaitWithCancellation<TOuter, TInner, TKey, TResult> : IUniTaskAsyncEnumerable<TResult>
    {
        private readonly IUniTaskAsyncEnumerable<TOuter> outer;
        private readonly IUniTaskAsyncEnumerable<TInner> inner;
        private readonly Func<TOuter, CancellationToken, UniTask<TKey>> outerKeySelector;
        private readonly Func<TInner, CancellationToken, UniTask<TKey>> innerKeySelector;
        private readonly Func<TOuter, IEnumerable<TInner>, CancellationToken, UniTask<TResult>> resultSelector;
        private readonly IEqualityComparer<TKey> comparer;

        public GroupJoinAwaitWithCancellation(IUniTaskAsyncEnumerable<TOuter> outer,
            IUniTaskAsyncEnumerable<TInner> inner, Func<TOuter, CancellationToken, UniTask<TKey>> outerKeySelector,
            Func<TInner, CancellationToken, UniTask<TKey>> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, CancellationToken, UniTask<TResult>> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            this.outer = outer;
            this.inner = inner;
            this.outerKeySelector = outerKeySelector;
            this.innerKeySelector = innerKeySelector;
            this.resultSelector = resultSelector;
            this.comparer = comparer;
        }

        public IUniTaskAsyncEnumerator<TResult> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _GroupJoinAwaitWithCancellation(outer, inner, outerKeySelector, innerKeySelector, resultSelector,
                comparer, cancellationToken);
        }

        private sealed class _GroupJoinAwaitWithCancellation : MoveNextSource, IUniTaskAsyncEnumerator<TResult>
        {
            private static readonly Action<object> MoveNextCoreDelegate = MoveNextCore;
            private static readonly Action<object> ResultSelectCoreDelegate = ResultSelectCore;
            private static readonly Action<object> OuterKeySelectCoreDelegate = OuterKeySelectCore;

            private readonly IUniTaskAsyncEnumerable<TOuter> outer;
            private readonly IUniTaskAsyncEnumerable<TInner> inner;
            private readonly Func<TOuter, CancellationToken, UniTask<TKey>> outerKeySelector;
            private readonly Func<TInner, CancellationToken, UniTask<TKey>> innerKeySelector;
            private readonly Func<TOuter, IEnumerable<TInner>, CancellationToken, UniTask<TResult>> resultSelector;
            private readonly IEqualityComparer<TKey> comparer;
            private CancellationToken cancellationToken;

            private ILookup<TKey, TInner> lookup;
            private IUniTaskAsyncEnumerator<TOuter> enumerator;
            private TOuter outerValue;
            private UniTask<bool>.Awaiter awaiter;
            private UniTask<TKey>.Awaiter outerKeyAwaiter;
            private UniTask<TResult>.Awaiter resultAwaiter;


            public _GroupJoinAwaitWithCancellation(IUniTaskAsyncEnumerable<TOuter> outer,
                IUniTaskAsyncEnumerable<TInner> inner, Func<TOuter, CancellationToken, UniTask<TKey>> outerKeySelector,
                Func<TInner, CancellationToken, UniTask<TKey>> innerKeySelector,
                Func<TOuter, IEnumerable<TInner>, CancellationToken, UniTask<TResult>> resultSelector,
                IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
            {
                this.outer = outer;
                this.inner = inner;
                this.outerKeySelector = outerKeySelector;
                this.innerKeySelector = innerKeySelector;
                this.resultSelector = resultSelector;
                this.comparer = comparer;
                this.cancellationToken = cancellationToken;
                TaskTracker.TrackActiveTask(this, 3);
            }

            public TResult Current { get; private set; }

            public UniTask<bool> MoveNextAsync()
            {
                cancellationToken.ThrowIfCancellationRequested();
                completionSource.Reset();

                if (lookup == null)
                    CreateLookup().Forget();
                else
                    SourceMoveNext();
                return new UniTask<bool>(this, completionSource.Version);
            }

            private async UniTaskVoid CreateLookup()
            {
                try
                {
                    lookup = await inner.ToLookupAwaitWithCancellationAsync(innerKeySelector, comparer,
                        cancellationToken);
                    enumerator = outer.GetAsyncEnumerator(cancellationToken);
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                    return;
                }

                SourceMoveNext();
            }

            private void SourceMoveNext()
            {
                try
                {
                    awaiter = enumerator.MoveNextAsync().GetAwaiter();
                    if (awaiter.IsCompleted)
                        MoveNextCore(this);
                    else
                        awaiter.SourceOnCompleted(MoveNextCoreDelegate, this);
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                }
            }

            private static void MoveNextCore(object state)
            {
                var self = (_GroupJoinAwaitWithCancellation)state;

                if (self.TryGetResult(self.awaiter, out var result))
                {
                    if (result)
                        try
                        {
                            self.outerValue = self.enumerator.Current;
                            self.outerKeyAwaiter = self.outerKeySelector(self.outerValue, self.cancellationToken)
                                .GetAwaiter();
                            if (self.outerKeyAwaiter.IsCompleted)
                                OuterKeySelectCore(self);
                            else
                                self.outerKeyAwaiter.SourceOnCompleted(OuterKeySelectCoreDelegate, self);
                        }
                        catch (Exception ex)
                        {
                            self.completionSource.TrySetException(ex);
                        }
                    else
                        self.completionSource.TrySetResult(false);
                }
            }

            private static void OuterKeySelectCore(object state)
            {
                var self = (_GroupJoinAwaitWithCancellation)state;

                if (self.TryGetResult(self.outerKeyAwaiter, out var result))
                    try
                    {
                        var values = self.lookup[result];
                        self.resultAwaiter = self.resultSelector(self.outerValue, values, self.cancellationToken)
                            .GetAwaiter();
                        if (self.resultAwaiter.IsCompleted)
                            ResultSelectCore(self);
                        else
                            self.resultAwaiter.SourceOnCompleted(ResultSelectCoreDelegate, self);
                    }
                    catch (Exception ex)
                    {
                        self.completionSource.TrySetException(ex);
                    }
            }

            private static void ResultSelectCore(object state)
            {
                var self = (_GroupJoinAwaitWithCancellation)state;

                if (self.TryGetResult(self.resultAwaiter, out var result))
                {
                    self.Current = result;
                    self.completionSource.TrySetResult(true);
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