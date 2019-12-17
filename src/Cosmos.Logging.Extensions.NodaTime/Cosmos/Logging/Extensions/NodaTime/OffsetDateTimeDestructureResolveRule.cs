using Cosmos.Logging.Extensions.NodaTime.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime {
    internal sealed class OffsetDateTimeDestructureResolveRule : NodaTimeDestructureResolveRule<OffsetDateTime> {
        protected override IPattern<OffsetDateTime> Pattern => OffsetDateTimePattern.Rfc3339;

        public OffsetDateTimeDestructureResolveRule() : base(CreateIsoValidator(x => x.Calendar)) { }
    }
}