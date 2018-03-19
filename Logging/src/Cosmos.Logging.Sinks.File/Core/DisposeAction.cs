using System;

namespace Cosmos.Logging.Sinks.File.Core {
    public class DisposeAction : IDisposable {
        private readonly Action _action;

        public DisposeAction(Action action) {
            _action = action;
        }

        public void Dispose() {
            _action?.Invoke();
        }
    }
}