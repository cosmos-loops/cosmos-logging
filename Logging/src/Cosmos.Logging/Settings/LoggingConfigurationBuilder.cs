using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

namespace Cosmos.Logging.Settings {
    public class LoggingConfigurationBuilder {
        private IConfigurationBuilder ConfigurationBuilder { get; set; }

        public LoggingConfigurationBuilder(IConfigurationBuilder builder = null) {
            ConfigurationBuilder = builder ?? new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            InitializedByGivenBuilder = builder != null;
        }
        
        public virtual bool InitializedByGivenBuilder { get; }

        public virtual LoggingConfigurationBuilder AddFile(string path, FileTypes fileType) {
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

        public virtual LoggingConfigurationBuilder AddJsonFile(string path) => AddFile(path, FileTypes.JSON);
        public virtual LoggingConfigurationBuilder AddXmlFile(string path) => AddFile(path, FileTypes.XML);
        public virtual LoggingConfigurationBuilder AddYamlFile(string path) => AddFile(path, FileTypes.YAML);

        public virtual IConfigurationRoot Build() => ConfigurationBuilder.Build();
    }
}