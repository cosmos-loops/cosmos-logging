using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Sinks.File.Core;

namespace Cosmos.Logging.Sinks.File {
    public class FileStrategy {
        public FileStrategy(string fileName, FilePath pathType, RollingInterval interval, List<string> namespaceList, string outputTemplate) {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;
            RollingInterval = interval;
            PathType = pathType;

            if (namespaceList == null || !namespaceList.Any()) {
                NamespaceList = new List<string> {"*"};
            } else {
                NamespaceList = namespaceList.AsReadOnly();
            }

            OutputTemplate = string.IsNullOrWhiteSpace(outputTemplate) ? Constants.DefaultOutputTemplate : outputTemplate;
        }

        public string FileName { get; }
        public FilePath PathType { get; }
        public RollingInterval RollingInterval { get; }
        public IReadOnlyList<string> NamespaceList { get; }
        public string OutputTemplate { get; }
    }
}