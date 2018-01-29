using System;
using Cosmos.Logging.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class DatabaseIntegration {
        private readonly ILogServiceCollection _service;

        public DatabaseIntegration(ILogServiceCollection service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public ILogServiceCollection ExposeServiceCollectionWrapper => _service;
    }
}