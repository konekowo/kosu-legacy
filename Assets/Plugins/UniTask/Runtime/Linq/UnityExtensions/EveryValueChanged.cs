using Cysharp.Threading.Tasks.Internal;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
    public static partial class UniTaskAsyncEnumerable
    {
        public static IUniTaskAsyncEnumerable<TProperty> EveryValueChanged<TTarget, TProperty>(TTarget target,
            Func<TTarget, TProperty> propertySelector, PlayerLoopTiming monitorTiming = PlayerLoopTiming.Update,
            IEqualityComparer<TProperty> equalityComparer = null)
            where TTarget : class
        {
            var unityObject = target as UnityEngine.Object;
            var isUnityObject = target is UnityEngine.Object; // don't use (unityObject == null)

            if (isUnityObject)
                return new EveryValueChangedUnityObject<TTarget, TProperty>(target, propertySelector,
                    equalityComparer ?? UnityEqualityComparer.GetDefault<TProperty>(), monitorTiming);
            else
                return new EveryValueChangedStandardObject<TTarget, TProperty>(target, propertySelector,
                    equalityComparer ?? UnityEqualityComparer.GetDefault<TProperty>(), monitorTiming);
        }
    }

    internal sealed class EveryValueChangedUnityObject<TTarget, TProperty> : IUniTaskAsyncEnumerable<TProperty>
    {
        private readonly TTarget target;
        private readonly Func<TTarget, TProperty> propertySelector;
        private readonly IEqualityComparer<TProperty> equalityComparer;
        private readonly PlayerLoopTiming monitorTiming;

        public EveryValueChangedUnityObject(TTarget target, Func<TTarget, TProperty> propertySelector,
            IEqualityComparer<TProperty> equalityComparer, PlayerLoopTiming monitorTiming)
        {
            this.target = target;
            this.propertySelector = propertySelector;
            this.equalityComparer = equalityComparer;
            this.monitorTiming = monitorTiming;
        }

        public IUniTaskAsyncEnumerator<TProperty> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _EveryValueChanged(target, propertySelector, equalityComparer, monitorTiming, cancellationToken);
        }

        private sealed class _EveryValueChanged : MoveNextSource, IUniTaskAsyncEnumerator<TProperty>, IPlayerLoopItem
        {
            private readonly TTarget target;
            private readonly UnityEngine.Object targetAsUnityObject;
            private readonly IEqualityComparer<TProperty> equalityComparer;
            private readonly Func<TTarget, TProperty> propertySelector;
            private CancellationToken cancellationToken;

            private bool first;
            private TProperty currentValue;
            private bool disposed;

            public _EveryValueChanged(TTarget target, Func<TTarget, TProperty> propertySelector,
                IEqualityComparer<TProperty> equalityComparer, PlayerLoopTiming monitorTiming,
                CancellationToken cancellationToken)
            {
                this.target = target;
                targetAsUnityObject = target as UnityEngine.Object;
                this.propertySelector = propertySelector;
                this.equalityComparer = equalityComparer;
                this.cancellationToken = cancellationToken;
                first = true;
                TaskTracker.TrackActiveTask(this, 2);
                PlayerLoopHelper.AddAction(monitorTiming, this);
            }

            public TProperty Current => currentValue;

            public UniTask<bool> MoveNextAsync()
            {
                // return false instead of throw
                if (disposed || cancellationToken.IsCancellationRequested) return CompletedTasks.False;

                if (first)
                {
                    first = false;
                    if (targetAsUnityObject == null) return CompletedTasks.False;
                    currentValue = propertySelector(target);
                    return CompletedTasks.True;
                }

                completionSource.Reset();
                return new UniTask<bool>(this, completionSource.Version);
            }

            public UniTask DisposeAsync()
            {
                if (!disposed)
                {
                    disposed = true;
                    TaskTracker.RemoveTracking(this);
                }

                return default;
            }

            public bool MoveNext()
            {
                if (disposed || cancellationToken.IsCancellationRequested ||
                    targetAsUnityObject == null) // destroyed = cancel.
                {
                    completionSource.TrySetResult(false);
                    DisposeAsync().Forget();
                    return false;
                }

                var nextValue = default(TProperty);
                try
                {
                    nextValue = propertySelector(target);
                    if (equalityComparer.Equals(currentValue, nextValue)) return true;
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                    DisposeAsync().Forget();
                    return false;
                }

                currentValue = nextValue;
                completionSource.TrySetResult(true);
                return true;
            }
        }
    }

    internal sealed class EveryValueChangedStandardObject<TTarget, TProperty> : IUniTaskAsyncEnumerable<TProperty>
        where TTarget : class
    {
        private readonly WeakReference<TTarget> target;
        private readonly Func<TTarget, TProperty> propertySelector;
        private readonly IEqualityComparer<TProperty> equalityComparer;
        private readonly PlayerLoopTiming monitorTiming;

        public EveryValueChangedStandardObject(TTarget target, Func<TTarget, TProperty> propertySelector,
            IEqualityComparer<TProperty> equalityComparer, PlayerLoopTiming monitorTiming)
        {
            this.target = new WeakReference<TTarget>(target, false);
            this.propertySelector = propertySelector;
            this.equalityComparer = equalityComparer;
            this.monitorTiming = monitorTiming;
        }

        public IUniTaskAsyncEnumerator<TProperty> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new _EveryValueChanged(target, propertySelector, equalityComparer, monitorTiming, cancellationToken);
        }

        private sealed class _EveryValueChanged : MoveNextSource, IUniTaskAsyncEnumerator<TProperty>, IPlayerLoopItem
        {
            private readonly WeakReference<TTarget> target;
            private readonly IEqualityComparer<TProperty> equalityComparer;
            private readonly Func<TTarget, TProperty> propertySelector;
            private CancellationToken cancellationToken;

            private bool first;
            private TProperty currentValue;
            private bool disposed;

            public _EveryValueChanged(WeakReference<TTarget> target, Func<TTarget, TProperty> propertySelector,
                IEqualityComparer<TProperty> equalityComparer, PlayerLoopTiming monitorTiming,
                CancellationToken cancellationToken)
            {
                this.target = target;
                this.propertySelector = propertySelector;
                this.equalityComparer = equalityComparer;
                this.cancellationToken = cancellationToken;
                first = true;
                TaskTracker.TrackActiveTask(this, 2);
                PlayerLoopHelper.AddAction(monitorTiming, this);
            }

            public TProperty Current => currentValue;

            public UniTask<bool> MoveNextAsync()
            {
                if (disposed || cancellationToken.IsCancellationRequested) return CompletedTasks.False;

                if (first)
                {
                    first = false;
                    if (!target.TryGetTarget(out var t)) return CompletedTasks.False;
                    currentValue = propertySelector(t);
                    return CompletedTasks.True;
                }

                completionSource.Reset();
                return new UniTask<bool>(this, completionSource.Version);
            }

            public UniTask DisposeAsync()
            {
                if (!disposed)
                {
                    disposed = true;
                    TaskTracker.RemoveTracking(this);
                }

                return default;
            }

            public bool MoveNext()
            {
                if (disposed || cancellationToken.IsCancellationRequested || !target.TryGetTarget(out var t))
                {
                    completionSource.TrySetResult(false);
                    DisposeAsync().Forget();
                    return false;
                }

                var nextValue = default(TProperty);
                try
                {
                    nextValue = propertySelector(t);
                    if (equalityComparer.Equals(currentValue, nextValue)) return true;
                }
                catch (Exception ex)
                {
                    completionSource.TrySetException(ex);
                    DisposeAsync().Forget();
                    return false;
                }

                currentValue = nextValue;
                completionSource.TrySetResult(true);
                return true;
            }
        }
    }
}