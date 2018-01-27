using System;
using System.IO;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Renders;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configurations {
    public class LoggingConfigurationBuilder {
        private IConfigurationBuilder ConfigurationBuilder { get; set; }
        private readonly MessageTemplateCachePreheater _messageTemplateCachePreheater = new MessageTemplateCachePreheater();

        public LoggingConfigurationBuilder(IConfigurationBuilder builder = null) {
            ConfigurationBuilder = builder ?? new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            InitializedByGivenBuilder = builder != null;
            BeforeBuild(ActiveMessageTemplatePreheater);
            BeforeBuild(ActiveCorePreferencesRenders);
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

        private Action<MessageTemplateCachePreheater> MessageTemplateCachePreheaterAction { get; set; }

        public void PreheatMessageTemplates(Action<MessageTemplateCachePreheater> preheatAct) {
            if (preheatAct != null) {
                MessageTemplateCachePreheaterAction += preheatAct;
            }
        }

        protected Action<LoggingConfigurationBuilder> BeforeBuildAction { get; set; }
        protected Action<LoggingConfiguration> AfterBuildAction { get; set; }

        public virtual LoggingConfiguration Build() {
            BeforeBuildAction?.Invoke(this);
            var loggingConfiguration = new LoggingConfiguration(ConfigurationBuilder.Build());
            AfterBuildAction?.Invoke(loggingConfiguration);
            return loggingConfiguration;
        }

        public void BeforeBuild(Action<LoggingConfigurationBuilder> action) {
            if (action != null) {
                BeforeBuildAction += action;
            }
        }

        public void AfterBuild(Action<LoggingConfiguration> action) {
            if (action != null) {
                AfterBuildAction += action;
            }
        }

        protected void ActiveCorePreferencesRenders(LoggingConfigurationBuilder builder) {
            CoreRenderActivation.ActiveCorePreferencesRenders();
        }

        protected void ActiveMessageTemplatePreheater(LoggingConfigurationBuilder builder) {
            MessageTemplateCachePreheaterAction?.Invoke(_messageTemplateCachePreheater);
        }

        protected void ActiveMessageParameterProcessor(LoggingConfiguration loggingConfiguration) {
            var destructure = loggingConfiguration.Destructure ?? new DestructureConfiguration();
            var resolver = new MessageParameterResolver(
                destructure.MaximumLengthOfString,
                destructure.MaximumLevelOfNestLevelLimited,
                destructure.MaximumLoopCountForCollection,
                destructure.AdditionalScalarTypes,
                destructure.AdditionalDestructureResolveRules,
                false);

            MessageParameterProcessorCache.Set(new MessageParameterProcessor(resolver, _messageTemplateCachePreheater));
        }
    }
}