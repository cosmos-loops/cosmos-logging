using Cosmos.Logging.Extensions.NodaTime.Core;
using NodaTime;
using NodaTime.Text;

namespace Cosmos.Logging.Extensions.NodaTime {
    internal sealed class LocalDateDestructureResolveRule : NodaTimeDestructureResolveRule<LocalDate> {
        protected override IPattern<LocalDate> Pattern => LocalDatePattern.Iso;

        public LocalDateDestructureResolveRule() : base(CreateIsoValidator(x => x.Calendar)) { }
    }
}