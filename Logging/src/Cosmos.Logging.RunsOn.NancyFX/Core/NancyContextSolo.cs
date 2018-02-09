using Cosmos.Logging.ExtraSupports;
using Nancy;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    public sealed class NancyContextSolo : ContextDataItem {

        public const string Name = "__COSMOS_NANCYFX_CTX";

        public NancyContextSolo(NancyContext value)
            : base(Name, typeof(NancyContext), value, false) { }

        public NancyContext GetContext() {
            return Value as NancyContext;
        }
    }
}