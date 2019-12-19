using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging {
    /// <summary>
    /// Interface for logging service provider
    /// </summary>
    public partial interface ILoggingServiceProvider {
        /// <summary>
        /// Get simple logger
        /// </summary>
        /// <returns></returns>
        ISimpleLogger GetSimpleLogger(string categoryName);
        
        /// <summary>
        /// Get simple logger
        /// </summary>
        /// <returns></returns>
        ISimpleLogger GetSimpleLogger<T>();
    }
}