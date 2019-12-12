using System;
using System.Linq;

namespace Cosmos.Logging.Extensions.Exceptions.Filters {
    /// <summary>
    /// Filter property by name (only). 
    /// </summary>
    public class IgnorePropertyByNameFilter : IExceptionPropertyFilter {
        private readonly string[] _propertiesToIgnore;

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnorePropertyByNameFilter"/> class.
        /// </summary>
        /// <param name="propertiesToIgnore">The properties to ignore.</param>
        public IgnorePropertyByNameFilter(params string[] propertiesToIgnore) => _propertiesToIgnore = propertiesToIgnore;

        /// <inheritdoc />
        public bool ShouldBeFiltered(Exception exception, string propertyName, object value) {
            if (_propertiesToIgnore is null)
                return false;

            return _propertiesToIgnore.Any(t => t.Equals(propertyName, StringComparison.Ordinal));
        }
    }
}