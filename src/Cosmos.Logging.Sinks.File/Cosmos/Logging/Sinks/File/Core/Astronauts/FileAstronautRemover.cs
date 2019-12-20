using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cosmos.Disposables;

namespace Cosmos.Logging.Sinks.File.Core.Astronauts {
    /// <summary>
    /// File astronaut remover
    /// </summary>
    public static class FileAstronautRemover {
        private static readonly Dictionary<int, IAstronaut> _astronautRegisterTable = new Dictionary<int, IAstronaut>();
        private static readonly Dictionary<int, int> _astronautCounter = new Dictionary<int, int>();
        private static readonly Dictionary<int, IAstronaut> _astronautDeleted = new Dictionary<int, IAstronaut>();
        private static readonly object _syncRoot = new object();
        private static readonly object _syncCounter = new object();
        private static readonly object _syncDelete = new object();

        private static readonly Timer _timer;

        static FileAstronautRemover() {
            var ts = TimeSpan.FromSeconds(10);
            _timer = new Timer(_ => ClearUselessAstronaut(), null, ts, ts);
        }


        private static void ClearUselessAstronaut() {
            lock (_syncCounter) {
                var hashCodeList = _astronautCounter.Where(x => x.Value < 1 && _astronautDeleted.ContainsKey(x.Key)).Select(x => x.Key).ToList();
                if (hashCodeList.Any()) {
                    foreach (var hashCode in hashCodeList) {
                        _astronautCounter.Remove(hashCode);
                        if (_astronautRegisterTable.TryGetValue(hashCode, out var astronaut)) {
                            (astronaut as IDisposable)?.Dispose();
                        }

                        _astronautRegisterTable.Remove(hashCode);
                        _astronautDeleted.Remove(hashCode);
                    }
                }
            }
        }

        /// <summary>
        /// Wait to remove
        /// </summary>
        /// <param name="hashcode"></param>
        /// <param name="astronaut"></param>
        public static void WaitToRemove(int hashcode, IAstronaut astronaut) {
            if (!_astronautDeleted.ContainsKey(hashcode)) {
                lock (_syncDelete) {
                    if (!_astronautDeleted.ContainsKey(hashcode)) {
                        _astronautDeleted.Add(hashcode, astronaut);
                    }
                }
            }
        }

        private static void UpdateCounter(int hashcode, int changed) {
            lock (_syncCounter) {
                if (_astronautCounter.TryGetValue(hashcode, out var counter)) {
                    _astronautCounter[hashcode] = counter + changed;
                }
                else if (changed > 0) {
                    _astronautCounter.Add(hashcode, changed);
                }
            }
        }

        public static IDisposable UsingRegister(int hashcode, IAstronaut astronaut) {
            UpdateCounter(hashcode, 1);

            if (!_astronautRegisterTable.ContainsKey(hashcode)) {
                lock (_syncRoot) {
                    if (!_astronautRegisterTable.ContainsKey(hashcode)) {
                        _astronautRegisterTable.Add(hashcode, astronaut);
                    }
                }
            }

            return new DisposableAction(() => UpdateCounter(hashcode, -1));
        }

        public static IDisposable UsingRegister(string path, IAstronaut astronaut) {
            return UsingRegister(path.GetHashCode(), astronaut);
        }
    }
}