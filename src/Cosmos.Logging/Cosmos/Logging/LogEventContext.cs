using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging {
    public class LogEventContext {
        private readonly IList<IAdditionalOperation> _additionalOperations;
        private readonly ContextData _contextData;

        public LogEventContext() {
            _additionalOperations = new List<IAdditionalOperation>();
            _contextData = new ContextData();
        }

        #region Additional operations

        internal IEnumerable<IAdditionalOperation> ExposeOpts() => _additionalOperations;

        public void ImportOpt(IAdditionalOperation opt) {
            if (opt == null) return;
            _additionalOperations.Add(opt);
        }

        public LogEventContext Opt(IAdditionalOperation opt) {
            ImportOpt(opt);
            return this;
        }

        #endregion

        #region Log event send mode

        internal LogEventSendMode SendMode { get; private set; } = LogEventSendMode.Customize;

        public LogEventContext FireAutomatically() {
            SendMode = LogEventSendMode.Automatic;
            return this;
        }

        public LogEventContext FireManually() {
            SendMode = LogEventSendMode.Manually;
            return this;
        }

        public LogEventContext FireAsDefault() {
            SendMode = LogEventSendMode.Customize;
            return this;
        }

        #endregion

        #region Message template rendering options

        internal RenderingConfiguration RenderingOptions { get; set; }

        public LogEventContext UseRenderingOptions(RenderingConfiguration renderingOptions) {
            RenderingOptions = renderingOptions;
            return this;
        }

        #endregion

        #region Log event tags

        private readonly List<string> _tags = new List<string>();

        public LogEventContext SetTags(params string[] tags) {
            if (tags == null) return this;
            for (var i = 0; i < tags.Length; i++) {
                if (string.IsNullOrWhiteSpace(tags[i])) continue;
                if (_tags.Contains(tags[i])) continue;
                _tags.Add(tags[i]);
            }

            return this;
        }

        internal IReadOnlyList<string> Tags => _tags;

        #endregion

        #region Log event property

        private readonly List<object> _parameters = new List<object>();

        public LogEventContext SetParameter(object parameter) {
            if (parameter == null) return this;
            _parameters.Add(parameter);
            return this;
        }

        internal IReadOnlyList<object> Parameters => _parameters;

        #endregion

        #region set context data

        public LogEventContext AddData(string name, object value, bool output = true) {
            _contextData.AddOrUpdateItem(name, value, output);
            return this;
        }

        public ContextData ExposeContextData() => _contextData;

        #endregion

    }
}