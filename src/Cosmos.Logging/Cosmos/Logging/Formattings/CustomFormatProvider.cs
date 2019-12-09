using System.Collections.Generic;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Custom format provider
    /// </summary>
    public abstract class CustomFormatProvider {
        /// <summary>
        /// Create command event
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public abstract IEnumerable<FormatEvent> CreateCommandEvent(string format = null);
    }
}