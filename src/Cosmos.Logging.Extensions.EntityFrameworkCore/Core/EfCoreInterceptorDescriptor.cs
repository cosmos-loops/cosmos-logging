using System;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Extensions.EntityFrameworkCore.Core {
    internal class EfCoreInterceptorDescriptor {
        private readonly EfCoreEnricherOptions _settings;
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public EfCoreInterceptorDescriptor(ILoggingServiceProvider loggingServiceProvider, IOptions<EfCoreEnricherOptions> settings) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _settings = settings?.Value;
        }
        
        internal ILoggingServiceProvider ExposeLoggingServiceProvider => _loggingServiceProvider;

        internal EfCoreEnricherOptions ExposeSettings => _settings;
        
        internal static EfCoreInterceptorDescriptor Instance { get; set; }
    }
}