using System;
using System.Collections.Generic;
using Cosmos.Logging.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.AspNetCore.Settings {
    public class AspNetCoreLogServiceCollection : ILogServiceCollection {
        private LoggingConfigurationBuilder _configurationBuilder;
        private readonly IServiceCollection _serviceCollection;
        private ILoggerSettings _settings { get; set; }
        private readonly Dictionary<string, ILogSinkSettings> _sinkSettings;
        private object _sinkUpdateLock = new object();
        private Action<IConfigurationRoot> _originConfigAction;

        private AspNetCoreLogServiceCollection() { }

        internal AspNetCoreLogServiceCollection(IServiceCollection services) : this(services, null) { }

        internal AspNetCoreLogServiceCollection(IServiceCollection services, IConfigurationRoot root) {
            _configurationBuilder = root == null
                ? new LoggingConfigurationBuilder()
                : new DisabledConfigurationBuilder(root);
            _serviceCollection = services ?? throw new ArgumentNullException(nameof(services));
            _settings = new LoggingSettings();
            _sinkSettings = new Dictionary<string, ILogSinkSettings>();

            BeGivenConfigurationBuilder = _configurationBuilder.InitializedByGivenBuilder;
            BeGivenConfigurationRoot = root != null;
        }

        public bool BeGivenConfigurationBuilder { get; }
        public bool BeGivenConfigurationRoot { get; }
        public IServiceCollection ExposeServices() => _serviceCollection;
        public ILoggerSettings ExposeLogSettings() => _settings;

        public ILogServiceCollection AddDependency(Action<IServiceCollection> dependencyAction) {
            throw new NotImplementedException();
        }

        public ILogServiceCollection AddSinkSettings<TSinkSettings>(TSinkSettings settings) where TSinkSettings : class, ILogSinkSettings, new() {
            throw new NotImplementedException();
        }

        public ILogServiceCollection AddOriginConfigAction(Action<IConfigurationRoot> configAction) {
            throw new NotImplementedException();
        }

        public ILogServiceCollection ModifyConfigurationBuilder(Action<LoggingConfigurationBuilder> builderAct) {
            throw new NotImplementedException();
        }
    }
}