using System;
using System.IO;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.MessageTemplates.PresetTemplates;
using Cosmos.Logging.Renders;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Logging configuration builder
    /// </summary>
    public class LoggingConfigurationBuilder {
        private IConfigurationBuilder ConfigurationBuilder { get; set; }
        private readonly MessageTemplateCachePreheater _messageTemplateCachePreheater = new MessageTemplateCachePreheater();

        /// <inheritdoc />
        protected LoggingConfigurationBuilder() {
            MessageTemplateCachePreheaterAction = TemplateStandardsActivation.RegisterToMessageTemplateCachePreheater;
            BeforeBuild(ActiveMessageTemplatePreheater);
            BeforeBuild(ActiveCorePreferencesRenderers);
            AfterBuild(ActiveMessageParameterProcessor);
        }

        /// <inheritdoc />
        public LoggingConfigurationBuilder(IConfigurationBuilder builder = null) : this() {
            ConfigurationBuilder = builder ?? new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            InitializedByGivenBuilder = builder != null;
        }

        /// <summary>
        /// Gets the flag that initialized by given builder
        /// </summary>
        public virtual bool InitializedByGivenBuilder { get; }

        /// <summary>
        /// Add configuration by file path and file type. Current just support json and xml
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Add json format configuration file by the given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual LoggingConfigurationBuilder AddJsonFile(string path) => AddFile(path, FileTypes.Json);

        /// <summary>
        /// Add xml format configuration file by the given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual LoggingConfigurationBuilder AddXmlFile(string path) => AddFile(path, FileTypes.Xml);

        private Action<MessageTemplateCachePreheater> MessageTemplateCachePreheaterAction { get; set; }

        /// <summary>
        /// Preheat message templates
        /// </summary>
        /// <param name="preheatAct"></param>
        public void PreheatMessageTemplates(Action<MessageTemplateCachePreheater> preheatAct) {
            if (preheatAct != null) {
                MessageTemplateCachePreheaterAction += preheatAct;
            }
        }

        /// <summary>
        /// Gets or sets action before build
        /// </summary>
        protected Action<LoggingConfigurationBuilder, ILoggingOptions> BeforeBuildAction { get; set; }

        /// <summary>
        /// Gets or sets action after build
        /// </summary>
        protected Action<LoggingConfiguration> AfterBuildAction { get; set; }

        /// <summary>
        /// Build configuration builder
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public virtual LoggingConfiguration Build(ILoggingOptions settings) {
            BeforeBuildAction?.Invoke(this, settings);
            var loggingConfiguration = new LoggingConfiguration(settings, ConfigurationBuilder.Build());
            AfterBuildAction?.Invoke(loggingConfiguration);
            return loggingConfiguration;
        }

        /// <summary>
        /// Do somethings before build
        /// </summary>
        /// <param name="action"></param>
        public void BeforeBuild(Action<LoggingConfigurationBuilder, ILoggingOptions> action) {
            if (action != null) {
                BeforeBuildAction += action;
            }
        }

        /// <summary>
        /// DO somethings after build
        /// </summary>
        /// <param name="action"></param>
        public void AfterBuild(Action<LoggingConfiguration> action) {
            if (action != null) {
                AfterBuildAction += action;
            }
        }

        /// <summary>
        /// Active core preferences renderers
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="settings"></param>
        protected void ActiveCorePreferencesRenderers(LoggingConfigurationBuilder builder, ILoggingOptions settings) {
            if (settings is LoggingOptions options) {
                if (options.AutomaticScanRendererEnabled) {
                    PreferencesRenderersScanner.Scan();
                }
                else {
                    PreferencesRenderersScanner.Given(options.ManuallyRendererTypes);
                }
            }
            else {
                PreferencesRenderersScanner.Scan();
            }
        }

        /// <summary>
        /// Active message template preheater
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="settings"></param>
        protected void ActiveMessageTemplatePreheater(LoggingConfigurationBuilder builder, ILoggingOptions settings) {
            MessageTemplateCachePreheaterAction?.Invoke(_messageTemplateCachePreheater);
        }

        /// <summary>
        /// Active message parameter processor
        /// </summary>
        /// <param name="loggingConfiguration"></param>
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