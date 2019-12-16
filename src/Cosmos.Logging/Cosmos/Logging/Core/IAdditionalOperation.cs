using System;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for additional operation
    /// </summary>
    public interface IAdditionalOperation {
        /// <summary>
        /// Type of additional operation type
        /// </summary>
        AdditionalOperationTypes Type { get; }

        /// <summary>
        /// Flag
        /// </summary>
        Type Flag { get; }

        /// <summary>
        /// Get opt
        /// </summary>
        /// <returns></returns>
        object GetOpt();
    }
}