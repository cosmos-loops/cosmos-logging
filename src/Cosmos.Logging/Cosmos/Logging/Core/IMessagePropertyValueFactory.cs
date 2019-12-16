using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for message property value factory
    /// </summary>
    public interface IMessagePropertyValueFactory {
        /// <summary>
        /// Create property value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mode"></param>
        /// <param name="positionalValue"></param>
        /// <returns></returns>
        MessagePropertyValue CreatePropertyValue(object value, PropertyResolvingMode mode, int positionalValue = -1);
    }
}