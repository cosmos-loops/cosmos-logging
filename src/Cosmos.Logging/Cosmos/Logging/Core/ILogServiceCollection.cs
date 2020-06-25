using System;
using Cosmos.Extensions.Dependency.Core;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.MessageTemplates;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for Cosmos Logging service collection
    /// </summary>
    public interface ILogServiceCollection {
        /// <summary>
        /// Be given configuration builder, or not.
        /// </summary>
        bool BeGivenConfigurationBuilder { get; }

        /// <summary>
        /// Be given configuration root, or not.
        /// </summary>
        bool BeGivenConfigurationRoot { get; }

        /// <summary>
        /// Expose Log settings
        /// </summary>
        /// <returns></returns>
        ILoggingOptions ExposeLogSettings();

        /// <summary>
        /// Expose logging configuration
        /// </summary>
        /// <returns></returns>
        LoggingConfiguration ExposeLoggingConfiguration();

        /// <summary>
        /// Add dependency
        /// </summary>
        /// <param name="dependencyAction"></param>
        /// <returns></returns>
        ILogServiceCollection AddDependency(Action<DependencyProxyRegister> dependencyAction);

        /// <summary>
        /// Add enricher
        /// </summary>
        /// <param name="enricherProvider"></param>
        /// <returns></returns>
        ILogServiceCollection AddEnricher(Func<ILogEventEnricher> enricherProvider);

        /// <summary>
        /// Add sink settings
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <typeparam name="TSinkSettings"></typeparam>
        /// <typeparam name="TSinkConfiguration"></typeparam>
        /// <returns></returns>
        ILogServiceCollection AddSinkSettings<TSinkSettings, TSinkConfiguration>(TSinkSettings settings, Action<IConfiguration, TSinkConfiguration> configAct)
            where TSinkSettings : class, ILoggingSinkOptions, new()
            where TSinkConfiguration : SinkConfiguration, new();

        /// <summary>
        /// Add extra sink settings
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="configAct"></param>
        /// <typeparam name="TExtraSinkSettings"></typeparam>
        /// <typeparam name="TExtraSinkConfiguration"></typeparam>
        /// <returns></returns>
        ILogServiceCollection AddExtraSinkSettings<TExtraSinkSettings, TExtraSinkConfiguration>(
            TExtraSinkSettings settings,
            Action<IConfiguration, TExtraSinkConfiguration, LoggingConfiguration> configAct)
            where TExtraSinkSettings : class, ILoggingSinkOptions, new()
            where TExtraSinkConfiguration : SinkConfiguration, new();

        /// <summary>
        /// Preheat message templates
        /// </summary>
        /// <param name="preheatAct"></param>
        /// <returns></returns>
        ILogServiceCollection PreheatMessageTemplates(Action<MessageTemplateCachePreheater> preheatAct);

        /// <summary>
        /// Add original configure action
        /// </summary>
        /// <param name="configAction"></param>
        /// <returns></returns>
        ILogServiceCollection AddOriginalConfigAction(Action<IConfiguration> configAction);

        /// <summary>
        /// Modify configuration builder
        /// </summary>
        /// <param name="builderAct"></param>
        /// <returns></returns>
        ILogServiceCollection ModifyConfigurationBuilder(Action<LoggingConfigurationBuilder> builderAct);
    }
}