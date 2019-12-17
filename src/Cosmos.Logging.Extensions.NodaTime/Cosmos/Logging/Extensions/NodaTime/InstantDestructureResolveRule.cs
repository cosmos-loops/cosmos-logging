using Cosmos.Logging.Extensions.NodaTime.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime {
    internal sealed class InstantDestructureResolveRule : NodaTimeDestructureResolveRule<Instant> {
        protected override IPattern<Instant> Pattern => InstantPattern.General;
    }
}