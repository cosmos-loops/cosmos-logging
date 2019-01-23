using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos
{
    /// <summary>
    /// Base service
    /// </summary>
    public abstract class DisposableObjects : IDisposable
    {
        private bool _disposed;
        private readonly IList<IDisposable> _disposableObjects;
        private readonly IDictionary<string, DisposableAction> _disposableActions;

        protected DisposableObjects()
        {
            _disposableObjects = new List<IDisposable>();
            _disposableActions = new Dictionary<string, DisposableAction>();
        }

        /// <summary>
        /// Hold on a disposable object.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="TDisposableObj"></typeparam>
        protected void AddDisposableObject<TDisposableObj>(TDisposableObj obj) where TDisposableObj : class, IDisposable
        {
            CheckDisposed();

            if (obj != null)
            {
                _disposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Hold on a group of disposable objects.
        /// </summary>
        /// <param name="objs"></param>
        protected void AddDisposableObjects(params object[] objs)
        {
            CheckDisposed();

            foreach (var obj in objs.Select(s => s as IDisposable).Where(o => o != null))
            {
                _disposableObjects.Add(obj);
            }
        }

        protected void AddDisposableAction(string name, DisposableAction action)
        {
            CheckDisposed();

            _disposableActions.Add(name, action);
        }

        protected void AddDisposableAction(string name, Action action)
        {
            CheckDisposed();

            _disposableActions.Add(name, new DisposableAction(action));
        }

        protected void RemoveDisposableAction(string name)
        {
            CheckDisposed();

            if (_disposableActions.ContainsKey(name))
            {
                _disposableActions.Remove(name);
            }
        }

        protected void ClearDisposableActions()
        {
            CheckDisposed();

            _disposableActions.Clear();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (var pair in _disposableActions)
                {
                    pair.Value?.Dispose();
                }

                foreach (var obj in _disposableObjects.Where(o => o != null))
                {
                    obj.Dispose();
                }

                _disposableActions.Clear();

                _disposableObjects.Clear();
            }

            _disposed = true;
        }

        private void CheckDisposed()
        {
            if (_disposed)
            {
                throw new InvalidOperationException("DisposableObjects instance has been disposed.");
            }
        }

        ~DisposableObjects()
        {
            Dispose(false);
        }
    }
}