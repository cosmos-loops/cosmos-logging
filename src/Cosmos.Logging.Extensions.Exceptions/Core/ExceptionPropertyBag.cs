using System;
using System.Collections.Generic;
using Cosmos.Logging.Extensions.Exceptions.Filters;

namespace Cosmos.Logging.Extensions.Exceptions.Core
{
    /// <inheritdoc />
    internal class ExceptionPropertyBag : IExceptionPropertyBag
    {
        private readonly Exception _exception;
        private readonly IExceptionPropertyFilter _filter;
        private readonly Dictionary<string, object> _properties;

        public ExceptionPropertyBag(Exception exception, IExceptionPropertyFilter filter = null)
        {
            _exception = exception ?? throw new ArgumentNullException(nameof(exception));
            _filter = filter;
            _properties = new Dictionary<string, object>();
        }

        private bool _resultsCollected = false;

        /// <inheritdoc />
        public IReadOnlyDictionary<string, object> GetProperties()
        {
            _resultsCollected = true;
            return _properties;
        }

        /// <inheritdoc />
        public void AddProperty(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (_resultsCollected)
                throw new InvalidOperationException($"Cannot add exception property '{key}' to bag, for results were already collected.");

            if (_filter != null)
            {
                if (_filter.ShouldBeFiltered(_exception, key, value))
                    return;
            }

            _properties.Add(key, value);
        }

        /// <inheritdoc />
        public bool ContainProperty(string key)
        {
            return _properties.ContainsKey(key);
        }
    }
}