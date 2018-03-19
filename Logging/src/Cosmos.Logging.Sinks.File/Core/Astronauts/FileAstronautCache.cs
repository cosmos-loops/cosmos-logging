using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Strategies;

namespace Cosmos.Logging.Sinks.File.Core.Astronauts {
    public class FileAstronautCache {
        private readonly Dictionary<SavingStrategy, int> _lastSavingPathCache;
        private readonly Dictionary<int, IAstronaut> _enabledFileAstronautCache;
        private readonly object _fileLockObj = new object();

        public FileAstronautCache() {
            _lastSavingPathCache = new Dictionary<SavingStrategy, int>();
            _enabledFileAstronautCache = new Dictionary<int, IAstronaut>();
        }

        private IAstronaut CreateAstronaut(SavingStrategy strategy, string path, long? fileSizeLimitBytes) {
            IAstronaut ret = new FileAstronaut(path, fileSizeLimitBytes);
            if (strategy.FlushToDiskInterval != null) {
                ret = new PeriodicAstronaut(ret, strategy.FlushToDiskInterval.Value);
            }

            return ret;
        }

        public bool TryGetFileAstronaut(SavingStrategy strategy, string givenPath, out IAstronaut fileAstronaut) {
            fileAstronaut = default(FileAstronaut);
            if (strategy == null) return false;
            if (string.IsNullOrWhiteSpace(givenPath)) return false;
            var givenPathHash = givenPath.GetHashCode();
            lock (_fileLockObj) {
                if (_lastSavingPathCache.TryGetValue(strategy, out var originalPathHash)) {
                    if (originalPathHash == givenPathHash) {
                        if (!_enabledFileAstronautCache.TryGetValue(originalPathHash, out fileAstronaut)) {
                            fileAstronaut = CreateAstronaut(strategy, givenPath, null);
                            _enabledFileAstronautCache[originalPathHash] = fileAstronaut;
                        }

                        return true;
                    } else {
                        if (_enabledFileAstronautCache.TryGetValue(originalPathHash, out fileAstronaut)) {
                            FileAstronautRemover.WaitToRemove(originalPathHash, fileAstronaut);
                            _enabledFileAstronautCache.Remove(originalPathHash);
                        }

                        fileAstronaut = CreateAstronaut(strategy, givenPath, null);
                        _lastSavingPathCache[strategy] = givenPathHash;
                        _enabledFileAstronautCache.Add(givenPathHash, fileAstronaut);
                        return true;
                    }
                } else {
                    fileAstronaut = CreateAstronaut(strategy, givenPath, null);
                    _lastSavingPathCache.Add(strategy, givenPathHash);
                    _enabledFileAstronautCache.Add(givenPathHash, fileAstronaut);
                    return true;
                }
            }
        }
    }
}