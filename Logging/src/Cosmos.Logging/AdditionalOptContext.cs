using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public class AdditionalOptContext {
        private readonly IList<IAdditionalOperation> _additionalOperations;

        public AdditionalOptContext() {
            _additionalOperations = new List<IAdditionalOperation>();
        }

        internal IEnumerable<IAdditionalOperation> ExposeOpts() => _additionalOperations;

        public void ImportOpt(IAdditionalOperation opt) {
            if (opt == null) return;
            _additionalOperations.Add(opt);
        }

        public LogEventSendMode SendMode { get; set; } = LogEventSendMode.Customize;
    }
}