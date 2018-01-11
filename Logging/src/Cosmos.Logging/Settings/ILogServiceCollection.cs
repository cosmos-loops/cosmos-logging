using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.Settings {
    public interface ILogServiceCollection {
        bool BeGivenConfigurationBuilder { get; }
        bool BeGivenConfigurationRoot { get; }
        IServiceCollection ExposeServices();
        ILoggerSettings ExposeLogSettings();
        ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction);
        ILogServiceCollection AddSinkSettings<TSinkSettings>(TSinkSettings settings) where TSinkSettings : class, ILogSinkSettings, new();
        ILogServiceCollection AddOriginConfigAction(Action<IConfigurationRoot> configAction);
        ILogServiceCollection ModifyConfigurationBuilder(Action<LoggingConfigurationBuilder> builderAct);
    }
}