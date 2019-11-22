using Cosmos.Logging.Events;

namespace Cosmos.Logging.ExtraSupports
{
    public static class ExtraMessagePropertyExtensions
    {
        public static ExtraMessageProperty AsExtra(this MessageProperty property) => new ExtraMessageProperty(property);
    }
}