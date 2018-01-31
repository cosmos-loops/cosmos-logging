using System.Data.Entity.Infrastructure.Interception;

namespace Cosmos.Logging.Sinks.EntityFramework.Core {
    internal class EfIntegrationActivation {
        public EfIntegrationActivation(EfInterceptorDescriptor descriptor) {
            DbInterception.Add(new EfIntegrationLoggerInterceptor(descriptor));
            DatabaseExtensions.LoggingServiceProvider = descriptor.ExposeLoggingServiceProvider;
            DatabaseExtensions.GlobalSimpleLogingInterceptor = descriptor.ExposeSettings.SimgleLoggingAction;
        }
    }
}