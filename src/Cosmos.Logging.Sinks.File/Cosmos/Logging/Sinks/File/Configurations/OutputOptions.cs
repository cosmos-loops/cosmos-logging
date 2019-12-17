using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Sinks.File.Configurations {
    /// <summary>
    /// Output options
    /// </summary>
    public class OutputOptions {
        /// <summary>
        /// Gets or sets path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets path type
        /// </summary>
        public PathType PathType { get; set; } = PathType.Absolute;
        /// <summary>
        /// Gets or sets template
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Gets or sets navigators
        /// </summary>
        public List<string> Navigators { get; set; }
        /// <summary>
        /// Gets or sets flush to disk interval value
        /// </summary>
        public TimeSpan? FlushToDiskInterval { get; set; }
        /// <summary>
        /// Gets or sets rolling interval value
        /// </summary>
        public RollingInterval Rolling { get; set; }
    }
}