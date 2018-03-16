using System;
using System.Threading;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Sinks.File.Core.Astronauts {
    public sealed class PeriodicAstronaut : IAstronaut, IDisposable {
        private readonly IAstronaut _astronaut;
        private readonly Timer _timer;
        int _flushRequired;

        public PeriodicAstronaut(IAstronaut astronaut, TimeSpan flushInterval) {
            _astronaut = astronaut ?? throw new ArgumentNullException(nameof(astronaut));
            if (_astronaut is IFlushableAstronaut flushable) {
                _timer = new Timer(_ => FlushToDisk(flushable), null, flushInterval, flushInterval);
            } else {
                _timer = new Timer(_ => { }, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                InternalLogger.WriteLine("{0} configured to flush {1}, but {2} not implemented", typeof(PeriodicAstronaut), astronaut, nameof(IFlushableAstronaut));
            }
        }

        void FlushToDisk(IFlushableAstronaut flushable) {
            try {
                if (Interlocked.CompareExchange(ref _flushRequired, 0, 1) == 1) {
                    flushable.FlushToDisk();
                }
            }
            catch (Exception exception) {
                InternalLogger.WriteLine("{0} could not flush the underlying sink to disk: {1}", typeof(PeriodicAstronaut), exception);
            }
        }

        public void Dispose() {
            _timer?.Dispose();
            (_astronaut as IDisposable)?.Dispose();
        }

        public void Save() {
            _astronaut.Save();
            Interlocked.Exchange(ref _flushRequired, 1);
        }
    }
}