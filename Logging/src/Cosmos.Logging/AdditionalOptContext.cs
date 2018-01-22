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

        public AdditionalOptContext Opt(IAdditionalOperation opt) {
            ImportOpt(opt);
            return this;
        }

        internal LogEventSendMode SendMode { get; private set; } = LogEventSendMode.Customize;

        public AdditionalOptContext FileAutomatically() {
            SendMode = LogEventSendMode.Automatic;
            return this;
        }

        public AdditionalOptContext FireManually() {
            SendMode = LogEventSendMode.Manually;
            return this;
        }

        public AdditionalOptContext FireAsDefault() {
            SendMode = LogEventSendMode.Customize;
            return this;
        }
    }
}