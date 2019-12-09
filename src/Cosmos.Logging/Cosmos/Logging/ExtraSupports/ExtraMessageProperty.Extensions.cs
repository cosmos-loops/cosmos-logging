using Cosmos.Logging.Events;

namespace Cosmos.Logging.ExtraSupports {
    /// <summary>
    /// Extensions for extra message property
    /// </summary>
    public static class ExtraMessagePropertyExtensions {
        /// <summary>
        /// As extra message property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static ExtraMessageProperty AsExtra(this MessageProperty property) => new ExtraMessageProperty(property);
    }
}