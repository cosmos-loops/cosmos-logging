using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessOptions : ILoggingSinkOptions<ExceptionlessOptions>, ILoggingSinkOptions {
        public string Key => Internals.Constants.SinkKey;
        public string Name => $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd}";

        #region Append min level

        internal LogEventLevel? InternalMinLevel { get; private set; }

        public ExceptionlessOptions UseMinLevel(LogEventLevel level) {
            InternalMinLevel = level;
            return this;
        }

        #endregion

        #region Append configuration file path

        internal string OriginConfigFilePath { get; set; }
        internal FileTypes OriginConfigFileType { get; set; } = FileTypes.JSON;

        public ExceptionlessOptions RemoveConfig() {
            OriginConfigFilePath = string.Empty;
            OriginConfigFileType = FileTypes.JSON;
            return this;
        }

        public ExceptionlessOptions UseAppSettings(string environmentName = "") {
            UseJsonConfig(string.IsNullOrWhiteSpace(environmentName) ? "appsettings.json" : $"appsettings.{environmentName}.json");
            return this;
        }

        public ExceptionlessOptions UseJsonConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.JSON;
            return this;
        }

        public ExceptionlessOptions UseXmlConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.XML;
            return this;
        }

        #endregion

        #region Append api key

        internal string ApiKey { get; set; }

        public ExceptionlessOptions UseApiKey(string apiKey) {
            ApiKey = apiKey;
            return this;
        }

        #endregion

    }
}