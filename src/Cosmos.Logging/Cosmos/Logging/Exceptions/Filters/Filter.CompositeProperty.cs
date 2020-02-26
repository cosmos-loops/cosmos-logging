using System;

namespace Cosmos.Logging.Exceptions.Filters {
    /// <summary>
    /// Composite property filter
    /// </summary>
    public class CompositePropertyFilter : IExceptionPropertyFilter {
        private readonly IExceptionPropertyFilter[] _filters;

        /// <inheritdoc />
        public CompositePropertyFilter(params IExceptionPropertyFilter[] filters) => _filters = Init(filters);

        /// <inheritdoc />
        public bool ShouldBeFiltered(Exception exception, string propertyName, object value) {
            for (var i = 0; i < _filters.Length; i++) {
                if (_filters[i].ShouldBeFiltered(exception, propertyName, value))
                    return true;
            }

            return false;
        }

        private static IExceptionPropertyFilter[] Init(IExceptionPropertyFilter[] filters) {
            if (filters is null)
                throw new ArgumentNullException(nameof(filters), "Cannot create composite property filter for null collection of filters was given.");

            if (filters.Length == 0)
                throw new ArgumentException("Cannot create composite property filter for empty collection of filters was given.", nameof(filters));

            for (var i = 0; i < filters.Length; i++) {
                if (filters[i] is null)
                    throw new ArgumentNullException(nameof(filters), $"Cannot create composite property filter for filter at index {i} is null.");
            }

            return filters;
        }
    }
}