using System;
using Cosmos.Logging.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public static class DatabaseIntegrationExtensions {
        public static ILogServiceCollection AddDatabaseIntegration(this ILogServiceCollection service, Action<DatabaseIntegration> integrationAct) {
            if (integrationAct == null) throw new ArgumentNullException(nameof(integrationAct));
            var integration = new DatabaseIntegration(service);
            integrationAct.Invoke(integration);
            return service;
        }
    }
}