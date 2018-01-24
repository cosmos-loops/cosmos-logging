using System;
using System.IO;
using Cosmos.Logging.Core.ObjectResolving;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configurations {
    public class LoggingConfigurationBuilder {
        private IConfigurationBuilder ConfigurationBuilder { get; set; }

        public LoggingConfigurationBuilder(IConfigurationBuilder builder = null) {
            ConfigurationBuilder = builder ?? new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            InitializedByGivenBuilder = builder != null;
            AfterBuild(ActiveMessageParameterProcessor);
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

                default:
                    throw new ArgumentException("Dost not support such tile type");
            }

            return this;
        }

        public virtual LoggingConfigurationBuilder AddJsonFile(string path) => AddFile(path, FileTypes.JSON);
        public virtual LoggingConfigurationBuilder AddXmlFile(string path) => AddFile(path, FileTypes.XML);

        private Action<LoggingConfiguration> AfterBuildAction { get; set; }

        public virtual LoggingConfiguration Build() {
            var loggingConfiguration = new LoggingConfiguration(ConfigurationBuilder.Build());
            AfterBuildAction?.Invoke(loggingConfiguration);
            return loggingConfiguration;
        }

        public void AfterBuild(Action<LoggingConfiguration> action) {
            if (action != null) {
                AfterBuildAction += action;
            }
        }

        private void ActiveMessageParameterProcessor(LoggingConfiguration loggingConfiguration) {
            var destructure = loggingConfiguration.Destructure ?? new DestructureConfiguration();
            var resolver = new MessageParameterResolver(
                destructure.MaximumLengthOfString,
                destructure.MaximumLevelOfNestLevelLimited,
                destructure.MaximumLoopCountForCollection,
                destructure.AdditionalScalarTypes,
                destructure.AdditionalDestructureResolveRules,
                false);

            MessageParameterProcessorCache.Set(new MessageParameterProcessor(resolver));
        }
    }
}