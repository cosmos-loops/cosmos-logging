using Cosmos.Logging.Extensions.NodaTime.Internals.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime.Internals
{
    internal sealed class LocalDateTimeDestructureResolveRule : NodaTimeDestructureResolveRule<LocalDateTime>
    {
        protected override IPattern<LocalDateTime> Pattern => LocalDateTimePattern.ExtendedIso;

        public LocalDateTimeDestructureResolveRule() : base(CreateIsoValidator(x => x.Calendar)) { }
    }
}