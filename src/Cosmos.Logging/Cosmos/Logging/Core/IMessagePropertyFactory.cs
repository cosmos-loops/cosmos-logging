using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for Message property factory
    /// </summary>
    public interface IMessagePropertyFactory {
        /// <summary>
        /// Create property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="mode"></param>
        /// <param name="positionalValue"></param>
        /// <returns></returns>
        MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int positionalValue = 0);
    }
}