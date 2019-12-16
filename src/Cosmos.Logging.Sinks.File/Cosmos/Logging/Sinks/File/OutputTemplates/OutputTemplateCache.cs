using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Output template cache
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
    public class OutputTemplateCache : IOutputTemplateParser {
        private readonly IOutputTemplateParser _outputTemplateParser;
        private readonly Hashtable _outputTemplateCache = new Hashtable();
        private readonly object _outputTemplateLock = new object();

        /// <summary>
        /// Create a new instance of <see cref="OutputTemplateCache"/>
        /// </summary>
        /// <param name="outputTemplateParser"></param>
        public OutputTemplateCache(IOutputTemplateParser outputTemplateParser) {
            _outputTemplateParser = outputTemplateParser ?? throw new ArgumentNullException(nameof(outputTemplateParser));
        }

        /// <inheritdoc />
        public OutputTemplate Parse(string outputTemplate) {
            if (string.IsNullOrWhiteSpace(outputTemplate)) throw new ArgumentNullException(nameof(outputTemplate));
            if (_outputTemplateCache[outputTemplate.GetHashCode()] is OutputTemplate result) return result;

            result = _outputTemplateParser.Parse(outputTemplate);
            lock (_outputTemplateLock) {
                _outputTemplateCache[outputTemplate.GetHashCode()] = result;
            }

            return result;
        }
    }
}