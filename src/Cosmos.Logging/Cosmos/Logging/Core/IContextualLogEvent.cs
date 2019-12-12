using System.Collections.Generic;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface contextual log event
    /// </summary>
    public interface IContextualLogEvent {
        /// <summary>
        /// Gets tags
        /// </summary>
        IReadOnlyList<string> Tags { get; }
    }
}