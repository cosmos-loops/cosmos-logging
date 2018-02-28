using System.IO;
using Cosmos.Logging.Sinks.File.Core;
using EnumsNET;

namespace Cosmos.Logging.Sinks.File.Strategies {
    public class SavingStrategy {
        private readonly string _path;
        private readonly string _basePath;
        private readonly PathType _pathType;
        private readonly RollingInterval _rolling;

        public SavingStrategy(string path, RollingInterval rolling, string basePath, PathType pathType) {
            _path = path;
            _rolling = rolling;
            _basePath = basePath;
            _pathType = pathType;
        }

        public string Path => _path;

        public RollingInterval Rolling => _rolling;

        public FormattingStrategy FormattingStrategy { get; set; }

        public PathType PathType => _pathType;

        public string GetFilePath() {
            return System.IO.Path.Combine(GetRealBasePath(), GetRealTargetPath());
        }

        private string GetRealTargetPath() {
            var indexOfLastPoint = _path.LastIndexOf('.');
            return indexOfLastPoint < 0
                ? $"{_path}{_rolling.GetFormat()}"
                : $"{_path.Substring(0, indexOfLastPoint)}{_rolling.GetFormat()}{_path.Substring(indexOfLastPoint + 1)}";
        }

        private string GetRealBasePath() {
            return _pathType == PathType.Absolute
                ? ""
                : string.IsNullOrWhiteSpace(_basePath)
                    ? Directory.GetCurrentDirectory()
                    : _basePath;
        }

        public override int GetHashCode() {
            return $"{_path}-{_rolling.GetName()}".GetHashCode();
        }
    }
}