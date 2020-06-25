using System;
using Cosmos.Logging.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console.Core {
    internal static partial class SoloDependencyContainer {
        public static ILogServiceCollection Initialize() {
            return Initialize(new ServiceCollection(), (IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services) {
            return Initialize(services, (IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services, IConfigurationBuilder builder) {
            if (services is null) throw new ArgumentNullException(nameof(services));
            return builder == null
                ? new ConsoleLogServiceCollection(services)
                : new ConsoleLogServiceCollection(services, builder);
        }

        public static ILogServiceCollection Initialize(IServiceCollection services, IConfigurationRoot root) {
            if (services is null) throw new ArgumentNullException(nameof(services));
            return root == null
                ? new ConsoleLogServiceCollection(services)
                : new ConsoleLogServiceCollection(services, root);
        }
    }
}