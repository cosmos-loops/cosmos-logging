using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Strategies;

namespace Cosmos.Logging.Sinks.File.Core.Astronauts {
    public class FileAstronautCache {
        private readonly Dictionary<SavingStrategy, int> _lastSavingPathCache;
        private readonly Dictionary<int, FileAstronaut> _enabledFileAstronautCache;
        private readonly object _fileLockObj = new object();

        public FileAstronautCache() {
            _lastSavingPathCache = new Dictionary<SavingStrategy, int>();
            _enabledFileAstronautCache = new Dictionary<int, FileAstronaut>();
        }

        public bool TryGetFileAstronaut(SavingStrategy strategy, string givenPath, out FileAstronaut fileAstronaut) {
            fileAstronaut = default(FileAstronaut);
            if (strategy == null) return false;
            if (string.IsNullOrWhiteSpace(givenPath)) return false;
            var givenPathHash = givenPath.GetHashCode();
            lock (_fileLockObj) {
                if (_lastSavingPathCache.TryGetValue(strategy, out var originalPathHash)) {
                    if (originalPathHash == givenPathHash) {
                        if (!_enabledFileAstronautCache.TryGetValue(originalPathHash, out fileAstronaut)) {
                            fileAstronaut = new FileAstronaut(givenPath, null);
                            _enabledFileAstronautCache[originalPathHash] = fileAstronaut;
                        }

                        return true;
                    } else {
                        fileAstronaut = new FileAstronaut(givenPath, null);
                        _lastSavingPathCache[strategy] = givenPathHash;
                        _enabledFileAstronautCache.Remove(originalPathHash);
                        _enabledFileAstronautCache.Add(givenPathHash, fileAstronaut);
                        return true;
                    }
                } else {
                    fileAstronaut = new FileAstronaut(givenPath, null);
                    _lastSavingPathCache.Add(strategy, givenPathHash);
                    _enabledFileAstronautCache.Add(givenPathHash, fileAstronaut);
                    return true;
                }
            }
        }
    }
}