using System;
using Cosmos.Logging.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Database integration
    /// </summary>
    public class DatabaseIntegration {
        private readonly ILogServiceCollection _service;

        /// <inheritdoc />
        public DatabaseIntegration(ILogServiceCollection service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Expose service collection wrapper
        /// </summary>
        public ILogServiceCollection ExposeServiceCollectionWrapper => _service;
    }
}