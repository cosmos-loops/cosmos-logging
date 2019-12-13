using System;
using System.IO;
using Cosmos.Logging.Core;
using Cosmos.Logging.Sinks.File.Core;
using EnumsNET;

namespace Cosmos.Logging.Sinks.File.Strategies {
    /// <summary>
    /// Saving strategy
    /// </summary>
    public class SavingStrategy {
        private readonly string _path;
        private readonly string _basePath;
        private readonly PathType _pathType;
        private readonly RollingInterval _rolling;
        private readonly TimeSpan? _flushToDiskInterval;

        /// <summary>
        /// Create a new instance of <see cref="SavingStrategy"/>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="rolling"></param>
        /// <param name="flushToDiskInterval"></param>
        /// <param name="basePath"></param>
        /// <param name="pathType"></param>
        public SavingStrategy(
            string path,
            RollingInterval rolling,
            TimeSpan? flushToDiskInterval,
            string basePath,
            PathType pathType) {
            _path = path;
            _rolling = rolling;
            _basePath = basePath;
            _pathType = pathType;
            _flushToDiskInterval = flushToDiskInterval;
        }

        /// <summary>
        /// Gets path
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// Gets rolling interval value
        /// </summary>
        public RollingInterval Rolling => _rolling;

        /// <summary>
        /// Gets flush to disk interval
        /// </summary>
        public TimeSpan? FlushToDiskInterval => _flushToDiskInterval;

        /// <summary>
        /// Gets or sets formatting strategy
        /// </summary>
        public FormattingStrategy FormattingStrategy { get; set; }

        /// <summary>
        /// Gets path type
        /// </summary>
        public PathType PathType => _pathType;

        /// <summary>
        /// Get file path
        /// </summary>
        /// <param name="logEventInfo"></param>
        /// <returns></returns>
        public string GetFilePath(ILogEventInfo logEventInfo) {
            return System.IO.Path.Combine(GetRealBasePath(), GetRealTargetPath(logEventInfo));
        }

        /// <summary>
        /// Check and get file path
        /// </summary>
        /// <param name="logEventInfo"></param>
        /// <returns></returns>
        public string CheckAndGetFilePath(ILogEventInfo logEventInfo) {
            var targetPath = GetFilePath(logEventInfo);

            if (!System.IO.File.Exists(targetPath)) {
                var fi = new FileInfo(targetPath);
                var di = fi.Directory;

                if (di == null) {
                    return string.Empty;
                }

                if (!di.Exists) {
                    di.Create();
                }
            }

            return targetPath;
        }

        private string GetRealTargetPath(ILogEventInfo logEventInfo) {
            var indexOfLastPoint = _path.LastIndexOf('.');
            return indexOfLastPoint < 0
                ? $"{_path}{logEventInfo.Timestamp.DateTime.ToString(_rolling.GetFormat())}"
                : $"{_path.Substring(0, indexOfLastPoint)}{logEventInfo.Timestamp.DateTime.ToString(_rolling.GetFormat())}.{_path.Substring(indexOfLastPoint + 1)}";
        }

        private string GetRealBasePath() {
            return _pathType == PathType.Absolute
                ? ""
                : string.IsNullOrWhiteSpace(_basePath)
                    ? Directory.GetCurrentDirectory()
                    : _basePath;
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return $"{_path}-{_rolling.GetName()}".GetHashCode();
        }
    }
}