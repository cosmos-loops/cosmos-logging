using System;
using System.Diagnostics.CodeAnalysis;
using Cosmos.Logging.Extensions.MicrosoftSupported;

namespace Cosmos.Logging.Extensions.DependencyInjection {
    
    /// <summary>
    /// Standard logging
    /// </summary>
    public class StandardLogServiceProvider : MicrosoftLoggingServiceProvider {
        /// <summary>
        /// Create a new instance of <see cref="StandardLogServiceProvider"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="loggingConfiguration"></param>
        public StandardLogServiceProvider(IServiceProvider provider, LoggingConfiguration loggingConfiguration) : base(provider, loggingConfiguration) { }
    }
}