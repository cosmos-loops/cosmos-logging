using System;

namespace Cosmos.Logging.Renders {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RendererAttribute : Attribute {
        public RendererAttribute(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
            SinkPrefix = string.Empty;
        }

        public RendererAttribute(string name, string sinkPrefix) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(sinkPrefix)) throw new ArgumentNullException(nameof(sinkPrefix));
            Name = name;
            SinkPrefix = sinkPrefix;
        }

        public string Name { get; }
        public string SinkPrefix { get; }
    }
}