using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

namespace Cosmos.Logging.Settings {
    public class LoggingConfigurationBuilder {
        private IConfigurationBuilder ConfigurationBuilder { get; set; }

        public LoggingConfigurationBuilder() {
            ConfigurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
        }

        public LoggingConfigurationBuilder AddFile(string path, FileTypes fileType) {
            switch (fileType) {
                case FileTypes.JSON:
                    ConfigurationBuilder.AddJsonFile(path, true, true);
                    break;

                case FileTypes.XML:
                    ConfigurationBuilder.AddXmlFile(path, true, true);
                    break;

                case FileTypes.YAML:
                    ConfigurationBuilder.AddYamlFile(path, true, true);
                    break;

                default:
                    throw new ArgumentException("Dost not support such tile type");
            }

            return this;
        }

        public LoggingConfigurationBuilder AddJsonFile(string path) => AddFile(path, FileTypes.JSON);
        public LoggingConfigurationBuilder AddXmlFile(string path) => AddFile(path, FileTypes.XML);
        public LoggingConfigurationBuilder AddYamlFile(string path) => AddFile(path, FileTypes.YAML);

        public IConfigurationRoot Build() => ConfigurationBuilder.Build();
    }
}