using System;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Extensions.EntityFrameworkCore.Core {
    internal class EfCoreInterceptorDescriptor {
        private readonly EfCoreSinkOptions _settings;
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public EfCoreInterceptorDescriptor(ILoggingServiceProvider loggingServiceProvider, IOptions<EfCoreSinkOptions> settings) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _settings = settings?.Value;
        }
        
        internal ILoggingServiceProvider ExposeLoggingServiceProvider => _loggingServiceProvider;

        internal EfCoreSinkOptions ExposeSettings => _settings;
        
        internal static EfCoreInterceptorDescriptor Instance { get; set; }
    }
}