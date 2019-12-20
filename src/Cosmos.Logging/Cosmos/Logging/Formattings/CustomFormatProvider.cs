using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Custom format provider
    /// </summary>
    public abstract class CustomFormatProvider {
        /// <summary>
        /// Gets a set of empty command event
        /// </summary>
        protected static readonly IEnumerable<FormatEvent> EmptyCommandEvents = Enumerable.Empty<FormatEvent>();

        /// <summary>
        /// Create command event
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public abstract IEnumerable<FormatEvent> CreateCommandEvent(string format = null);

        /// <summary>
        /// Merge
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        protected static IEnumerable<FormatEvent> Merge(params FormatEvent?[] events) {
            return from @event in events where @event.HasValue select @event.Value;
        }
    }
}