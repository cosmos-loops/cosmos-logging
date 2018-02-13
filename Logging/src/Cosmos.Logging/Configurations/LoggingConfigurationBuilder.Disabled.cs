using System;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configurations {
    public sealed class DisabledConfigurationBuilder : LoggingConfigurationBuilder {
        private readonly IConfigurationRoot _root;

        public DisabledConfigurationBuilder(IConfigurationRoot root) {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public override bool InitializedByGivenBuilder => false;

        public override LoggingConfigurationBuilder AddFile(string path, FileTypes fileType) => this;

        public override LoggingConfigurationBuilder AddJsonFile(string path) => this;

        public override LoggingConfigurationBuilder AddXmlFile(string path) => this;

        public override LoggingConfiguration Build(ILoggingOptions settings) {
            BeforeBuildAction?.Invoke(this, settings);
            var loggingConfiguration = new LoggingConfiguration(settings, _root);
            AfterBuildAction?.Invoke(loggingConfiguration);
            return loggingConfiguration;
        }
    }
}