using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Sinks.File.Core;

namespace Cosmos.Logging.Sinks.File {
    /// <summary>
    /// File strategy
    /// </summary>
    public class FileStrategy {

        /// <summary>
        /// Create a new instance of <see cref="LocalFileLogPayloadClient"/>
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="pathType"></param>
        /// <param name="interval"></param>
        /// <param name="namespaceList"></param>
        /// <param name="outputTemplate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FileStrategy(string fileName, PathType pathType, RollingInterval interval, List<string> namespaceList, string outputTemplate) {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;
            RollingInterval = interval;
            PathType = pathType;

            if (namespaceList == null || !namespaceList.Any()) {
                NamespaceList = new List<string> {"*"};
            }
            else {
                NamespaceList = namespaceList.AsReadOnly();
            }

            OutputTemplate = string.IsNullOrWhiteSpace(outputTemplate) ? Constants.DefaultOutputTemplate : outputTemplate;
        }

        /// <summary>
        /// Gets file name
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets path type
        /// </summary>
        public PathType PathType { get; }

        /// <summary>
        /// Gets rolling interval
        /// </summary>
        public RollingInterval RollingInterval { get; }

        /// <summary>
        /// Gets namespace list
        /// </summary>
        public IReadOnlyList<string> NamespaceList { get; }

        /// <summary>
        /// Gets output template
        /// </summary>
        public string OutputTemplate { get; }
    }
}