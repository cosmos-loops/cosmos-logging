using Cosmos.Logging.Sinks.File.Core;
using EnumsNET;

namespace Cosmos.Logging.Sinks.File.Strategies {
    public class SavingStrategy {
        private readonly string _path;
        private readonly RollingInterval _rolling;

        public SavingStrategy(string path, RollingInterval rolling) {
            _path = path;
            _rolling = rolling;
        }

        public string Path => _path;
        public RollingInterval Rolling => _rolling;

        public FormattingStrategy FormattingStrategy { get; set; }

        public string GetFilePath() {
            string targetFilePath;
            var indexOfLastPoint = Path.LastIndexOf('.');
            if (indexOfLastPoint < 0) {
                targetFilePath = Path + Rolling.GetFormat();
            } else {
                targetFilePath = Path.Substring(0, indexOfLastPoint) + Rolling.GetFormat() + Path.Substring(indexOfLastPoint + 1);
            }

            return targetFilePath;
        }

        public override int GetHashCode() {
            return $"{_path}-{_rolling.GetName()}".GetHashCode();
        }
    }
}