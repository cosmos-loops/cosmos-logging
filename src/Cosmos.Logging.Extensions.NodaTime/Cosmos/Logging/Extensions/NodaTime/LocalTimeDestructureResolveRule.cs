using Cosmos.Logging.Extensions.NodaTime.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime {
    internal sealed class LocalTimeDestructureResolveRule : NodaTimeDestructureResolveRule<LocalTime> {
        protected override IPattern<LocalTime> Pattern => LocalTimePattern.ExtendedIso;
    }
}