using Cosmos.Logging.Extensions.NodaTime.Internals.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime.Internals {
    internal sealed class InstantDestructureResolveRule : NodaTimeDestructureResolveRule<Instant> {
        protected override IPattern<Instant> Pattern => InstantPattern.General;
    }
}