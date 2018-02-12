using System.Data.Entity.Infrastructure.Interception;

namespace Cosmos.Logging.Extensions.EntityFramework.Core {
    internal class EfIntegrationActivation {
        public EfIntegrationActivation(EfInterceptorDescriptor descriptor) {
            DbInterception.Add(new EfIntegrationLoggerInterceptor(descriptor));
            DatabaseExtensions.LoggingServiceProvider = descriptor.ExposeLoggingServiceProvider;
            DatabaseExtensions.GlobalSimpleLoggingInterceptor = descriptor.ExposeSettings.SimgleLoggingAction;
            DatabaseExtensions.Settings = descriptor.ExposeSettings;
        }
    }
}