using Cosmos.Logging.Exceptions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// Interface for exception destructuring accessor
    /// </summary>
    public interface IExceptionDestructuringAccessor {
        /// <summary>
        /// Get an instance of <see cref="ExceptionDestructuringProcessor"/>
        /// </summary>
        /// <returns></returns>
        ExceptionDestructuringProcessor Get();
    }
}