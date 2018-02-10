using Cosmos.Logging.ExtraSupports;
using Nancy;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    public sealed class NancyContextSolo : ContextDataItem {

        public NancyContextSolo(NancyContext value)
            : base(Constants.NancyContextName, typeof(NancyContext), value, false) { }

        public NancyContext GetContext() {
            return Value as NancyContext;
        }
    }
}