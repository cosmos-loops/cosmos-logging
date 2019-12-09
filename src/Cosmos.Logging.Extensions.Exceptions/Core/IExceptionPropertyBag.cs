using System.Collections.Generic;

namespace Cosmos.Logging.Extensions.Exceptions.Core {
    /// <summary>
    /// To contain all properties of a single exception instance.
    /// All properties should be added before this bag is requested.
    /// </summary>
    public interface IExceptionPropertyBag {
        /// <summary>
        /// Gets all properties of the exception instance.
        /// </summary>
        /// <returns></returns>
        IReadOnlyDictionary<string, object> GetProperties();

        /// <summary>
        /// Add property
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddProperty(string key, object value);

        /// <summary>
        /// Returns  <c>true</c> if given key is already present in the bag. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainProperty(string key);
    }
}