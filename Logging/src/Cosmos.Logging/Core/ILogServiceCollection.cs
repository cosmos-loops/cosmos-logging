using System;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.Core {
    public interface ILogServiceCollection {
        bool BeGivenConfigurationBuilder { get; }
        bool BeGivenConfigurationRoot { get; }
        IServiceCollection ExposeServices();
        ILoggerSettings ExposeLogSettings();
        ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction);

        ILogServiceCollection AddSinkSettings<TSinkSettings, TSinkConfiguration>(TSinkSettings settings, Action<IConfiguration, TSinkConfiguration> configAct)
            where TSinkSettings : class, ILogSinkSettings, new()
            where TSinkConfiguration : SinkConfiguration, new();

        ILogServiceCollection AddOriginConfigAction(Action<IConfiguration> configAction);
        ILogServiceCollection ModifyConfigurationBuilder(Action<LoggingConfigurationBuilder> builderAct);
    }
}