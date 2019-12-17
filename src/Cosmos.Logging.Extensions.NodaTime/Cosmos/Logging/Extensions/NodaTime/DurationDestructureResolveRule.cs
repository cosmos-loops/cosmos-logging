using Cosmos.Logging.Extensions.NodaTime.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime {
    internal sealed class DurationDestructureResolveRule : NodaTimeDestructureResolveRule<Duration> {
        protected override IPattern<Duration> Pattern => DurationPattern.CreateWithInvariantCulture("-H:mm:ss.FFFFFFFFF");
    }
}