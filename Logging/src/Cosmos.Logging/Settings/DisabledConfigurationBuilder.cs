using System;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Settings {
    public class DisabledConfigurationBuilder : LoggingConfigurationBuilder {
        private readonly IConfigurationRoot _root;

        public DisabledConfigurationBuilder(IConfigurationRoot root) {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public override bool InitializedByGivenBuilder => false;

        public override LoggingConfigurationBuilder AddFile(string path, FileTypes fileType) {
            return this;
        }

        public override LoggingConfigurationBuilder AddJsonFile(string path) {
            return this;
        }

        public override LoggingConfigurationBuilder AddXmlFile(string path) {
            return this;
        }

        public override LoggingConfigurationBuilder AddYamlFile(string path) {
            return this;
        }

        public override IConfigurationRoot Build() {
            return _root;
        }
    }
}