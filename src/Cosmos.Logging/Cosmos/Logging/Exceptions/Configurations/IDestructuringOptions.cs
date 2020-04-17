using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Destructurers;
using Cosmos.Logging.Exceptions.Filters;

namespace Cosmos.Logging.Exceptions.Configurations {
    /// <summary>
    /// Interface for Destructuring options
    /// </summary>
    public interface IDestructuringOptions {
        /// <summary>
        /// Name for the key in log-context for the exception destructured info.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Depth at which reflection based destructurer will stop recursive process of children destructuring.
        /// Default is <c>10</c>
        /// </summary>
        int DestructureDepth { get; }

        /// <summary>
        /// Destructurers
        /// </summary>
        IEnumerable<IExceptionDestructurer> Destructurers { get; }

        /// <summary>
        /// Filter
        /// </summary>
        IExceptionPropertyFilter Filter { get; }
    }
}