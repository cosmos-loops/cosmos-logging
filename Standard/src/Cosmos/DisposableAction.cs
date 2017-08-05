using System;

namespace Cosmos
{
    public sealed class DisposableAction : IDisposable
    {
        private readonly Action _action;

        public DisposableAction(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            _action?.Invoke();
        }
    }
}
