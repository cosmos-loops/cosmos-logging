using System;
using System.IO;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Renders;
using Cosmos.Logging.TemplateStandards;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configurations {
    public class LoggingConfigurationBuilder {
        private IConfigurationBuilder ConfigurationBuilder { get; set; }
        private readonly MessageTemplateCachePreheater _messageTemplateCachePreheater = new MessageTemplateCachePreheater();

        protected LoggingConfigurationBuilder() {
            MessageTemplateCachePreheaterAction = TemplateStandardsActivation.RegisterToMessageTemplateCachePreheater;
            BeforeBuild(ActiveMessageTemplatePreheater);
            BeforeBuild(ActiveCorePreferencesRenders);
            AfterBuild(ActiveMessageParameterProcessor);
        }

        public LoggingConfigurationBuilder(IConfigurationBuilder builder = null) : this() {
            ConfigurationBuilder = builder ?? new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            InitializedByGivenBuilder = builder != null;
        }

        public virtual bool InitializedByGivenBuilder { get; }

        public virtual LoggingConfigurationBuilder AddFile(string path, FileTypes fileType) {
            switch (fileType) {
                case FileTypes.Json:
                    ConfigurationBuilder.AddJsonFile(path, true, true);
                    break;

                case FileTypes.Xml:
                    ConfigurationBuilder.AddXmlFile(path, true, true);
                    break;

                default:
                    throw new ArgumentException("Dost not support such tile type");
            }

            return this;
        }

        public virtual LoggingConfigurationBuilder AddJsonFile(string path) => AddFile(path, FileTypes.Json);
        public virtual LoggingConfigurationBuilder AddXmlFile(string path) => AddFile(path, FileTypes.Xml);

        private Action<MessageTemplateCachePreheater> MessageTemplateCachePreheaterAction { get; set; }

        public void PreheatMessageTemplates(Action<MessageTemplateCachePreheater> preheatAct) {
            if (preheatAct != null) {
                MessageTemplateCachePreheaterAction += preheatAct;
            }
        }

        protected Action<LoggingConfigurationBuilder> BeforeBuildAction { get; set; }
        protected Action<LoggingConfiguration> AfterBuildAction { get; set; }

        public virtual LoggingConfiguration Build(ILoggingOptions settings) {
            BeforeBuildAction?.Invoke(this);
            var loggingConfiguration = new LoggingConfiguration(settings, ConfigurationBuilder.Build());
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