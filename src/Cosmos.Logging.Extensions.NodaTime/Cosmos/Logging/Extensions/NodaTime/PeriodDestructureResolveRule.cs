using Cosmos.Logging.Extensions.NodaTime.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime {
    internal sealed class PeriodDestructureResolveRule : NodaTimeDestructureResolveRule<Period> {
        protected override IPattern<Period> Pattern => PeriodPattern.Roundtrip;
    }
}