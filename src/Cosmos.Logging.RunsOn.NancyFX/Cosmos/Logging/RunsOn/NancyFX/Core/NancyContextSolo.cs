using Cosmos.Logging.ExtraSupports;
using Nancy;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    /// <summary>
    /// Solo NancyFX context
    /// </summary>
    public sealed class NancyContextSolo : ContextDataItem {

        /// <inheritdoc />
        public NancyContextSolo(NancyContext value)
            : base(Constants.NancyContextName, typeof(NancyContext), value, false) { }

        /// <summary>
        /// Gets context
        /// </summary>
        /// <returns></returns>
        public NancyContext GetContext() {
            return Value as NancyContext;
        }
    }
}