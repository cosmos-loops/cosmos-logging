using System;
using Cosmos.Logging.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for database integration
    /// </summary>
    public static class DatabaseIntegrationExtensions {
        /// <summary>
        /// Add database integration
        /// </summary>
        /// <param name="service"></param>
        /// <param name="integrationAct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogServiceCollection AddDatabaseIntegration(this ILogServiceCollection service, Action<DatabaseIntegration> integrationAct) {
            if (integrationAct == null) throw new ArgumentNullException(nameof(integrationAct));
            var integration = new DatabaseIntegration(service);
            integrationAct.Invoke(integration);
            return service;
        }
    }
}