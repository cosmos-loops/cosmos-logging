using System;

namespace Cosmos.Logging.Extensions.Exceptions.Filters {
    /// <summary>
    /// Interface used for filtering exception properties.
    /// Filtering process is global, each property of every exception
    /// will go through a configured exception property filter.
    /// </summary>
    public interface IExceptionPropertyFilter {
        /// <summary>
        /// Should this property by filtered, no not.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ShouldBeFiltered(Exception exception, string propertyName, object value);
    }
}