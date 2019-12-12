using Cosmos.Logging.Extensions.NodaTime.Internals.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime.Internals {
    internal sealed class PeriodDestructureResolveRule : NodaTimeDestructureResolveRule<Period> {
        protected override IPattern<Period> Pattern => PeriodPattern.Roundtrip;
    }
}