using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging {
    /// <summary>
    /// Log event context
    /// </summary>
    public class LogEventContext {
        private readonly IList<IAdditionalOperation> _additionalOperations;
        private readonly ContextData _contextData;

        /// <summary>
        /// Create a new instance of <see cref="LogEventContext"/>
        /// </summary>
        public LogEventContext() {
            _additionalOperations = new List<IAdditionalOperation>();
            _contextData = new ContextData();
        }

        /// <summary>
        /// Create a new instance of <see cref="LogEventContext"/>
        /// </summary>
        /// <param name="context"></param>
        public LogEventContext(ContextData context) {
            _additionalOperations = new List<IAdditionalOperation>();
            _contextData = context ?? new ContextData();
        }

        #region Additional operations

        internal IEnumerable<IAdditionalOperation> ExposeOpts() => _additionalOperations;

        /// <summary>
        /// Import operation
        /// </summary>
        /// <param name="opt"></param>
        public void ImportOpt(IAdditionalOperation opt) {
            if (opt == null) return;
            _additionalOperations.Add(opt);
        }

        /// <summary>
        /// Operation
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        public LogEventContext Opt(IAdditionalOperation opt) {
            ImportOpt(opt);
            return this;
        }

        #endregion

        #region Log event send mode

        internal LogEventSendMode SendMode { get; private set; } = LogEventSendMode.Customize;

        /// <summary>
        /// Fire atuomativally
        /// </summary>
        /// <returns></returns>
        public LogEventContext FireAutomatically() {
            SendMode = LogEventSendMode.Automatic;
            return this;
        }

        /// <summary>
        /// Fire manually
        /// </summary>
        /// <returns></returns>
        public LogEventContext FireManually() {
            SendMode = LogEventSendMode.Manually;
            return this;
        }

        /// <summary>
        /// Fire default
        /// </summary>
        /// <returns></returns>
        public LogEventContext FireAsDefault() {
            SendMode = LogEventSendMode.Customize;
            return this;
        }

        #endregion

        #region Message template rendering options

        internal RenderingConfiguration RenderingOptions { get; set; }

        /// <summary>
        /// Use rendering options
        /// </summary>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public LogEventContext UseRenderingOptions(RenderingConfiguration renderingOptions) {
            RenderingOptions = renderingOptions;
            return this;
        }

        #endregion

        #region Log event tags

        private readonly List<string> _tags = new List<string>();

        /// <summary>
        /// Set tags
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Set parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public LogEventContext SetParameter(object parameter) {
            if (parameter == null) return this;
            _parameters.Add(parameter);
            return this;
        }

        internal IReadOnlyList<object> Parameters => _parameters;

        #endregion

        #region set context data

        /// <summary>
        /// Add data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public LogEventContext AddData(string name, object value, bool output = true) {
            _contextData.AddOrUpdateItem(name, value, output);
            return this;
        }

        /// <summary>
        /// Expose context data
        /// </summary>
        /// <returns></returns>
        public ContextData ExposeContextData() => _contextData;

        #endregion

    }
}