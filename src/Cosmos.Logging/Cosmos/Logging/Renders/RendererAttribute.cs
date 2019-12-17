using System;

namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Renderer attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RendererAttribute : Attribute {
        /// <inheritdoc />
        public RendererAttribute(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
            SinkPrefix = string.Empty;
        }

        /// <inheritdoc />
        public RendererAttribute(string name, string sinkPrefix) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(sinkPrefix)) throw new ArgumentNullException(nameof(sinkPrefix));
            Name = name;
            SinkPrefix = sinkPrefix;
        }

        /// <summary>
        /// Gets name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets sink prefix
        /// </summary>
        public string SinkPrefix { get; }
    }
}