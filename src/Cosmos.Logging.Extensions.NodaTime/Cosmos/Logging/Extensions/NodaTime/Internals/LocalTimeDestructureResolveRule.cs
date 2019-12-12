using Cosmos.Logging.Extensions.NodaTime.Internals.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime.Internals {
    internal sealed class LocalTimeDestructureResolveRule : NodaTimeDestructureResolveRule<LocalTime> {
        protected override IPattern<LocalTime> Pattern => LocalTimePattern.ExtendedIso;
    }
}