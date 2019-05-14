using Cosmos.Logging.Extensions.NodaTime.Internals.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime.Internals
{
    internal sealed class OffsetDateTimeDestructureResolveRule : NodaTimeDestructureResolveRule<OffsetDateTime>
    {
        protected override IPattern<OffsetDateTime> Pattern => OffsetDateTimePattern.Rfc3339;

        public OffsetDateTimeDestructureResolveRule() : base(CreateIsoValidator(x => x.Calendar)) { }
    }
}