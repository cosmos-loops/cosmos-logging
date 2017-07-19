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
        private bool _disposed = false;
        private readonly IList<IDisposable> _disposableObjects;

        protected DisposableObjects()
        {
            _disposableObjects = new List<IDisposable>();
        }

        protected void AddDisposableObject<TDisposableObj>(TDisposableObj obj) where TDisposableObj : class, IDisposable
        {
            _disposableObjects.Add(obj);
        }

        protected void AddDisposableObjects(params object[] objs)
        {
            foreach (var obj in objs.Select(s => s as IDisposable).Where(o => o != null))
            {
                _disposableObjects.Add(obj);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (var obj in _disposableObjects.Where(o => o != null))
                {
                    obj.Dispose();
                }
            }

            _disposed = true;
        }

        ~DisposableObjects()
        {
            Dispose(false);
        }
    }
}
