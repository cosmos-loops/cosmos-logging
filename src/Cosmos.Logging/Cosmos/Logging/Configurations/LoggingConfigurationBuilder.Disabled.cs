using System;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Disabled configuration builder
    /// </summary>
    public sealed class DisabledConfigurationBuilder : LoggingConfigurationBuilder {
        private readonly IConfigurationRoot _root;

        /// <inheritdoc />
        public DisabledConfigurationBuilder(IConfigurationRoot root) {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        /// <inheritdoc />
        public override bool InitializedByGivenBuilder => false;

        /// <inheritdoc />
        public override LoggingConfigurationBuilder AddFile(string path, FileTypes fileType) => this;

        /// <inheritdoc />
        public override LoggingConfigurationBuilder AddJsonFile(string path) => this;

        /// <inheritdoc />
        public override LoggingConfigurationBuilder AddXmlFile(string path) => this;

        /// <inheritdoc />
        public override LoggingConfiguration Build(ILoggingOptions settings) {
            BeforeBuildAction?.Invoke(this, settings);
            var loggingConfiguration = new LoggingConfiguration(settings, _root);
            AfterBuildAction?.Invoke(loggingConfiguration);
            return loggingConfiguration;
        }
    }
}