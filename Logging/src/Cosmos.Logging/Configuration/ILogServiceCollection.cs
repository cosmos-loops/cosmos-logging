using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.Configuration {
    public interface ILogServiceCollection {
        IServiceCollection ExposeServices();
        ILoggerSettings ExposeLogSettings();
        ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction);
        ILogServiceCollection AddSinkSettings<TSinkSettings>(TSinkSettings settings) where TSinkSettings : class, ILogSinkSettings, new();
    }
}