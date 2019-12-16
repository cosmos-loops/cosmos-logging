using System;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for second initializing activation
    /// </summary>
    public interface ISecInitializingActivation {
        /// <summary>
        /// Get second processing action.
        /// </summary>
        /// <returns></returns>
        Action GetSecProcessing();
    }
}