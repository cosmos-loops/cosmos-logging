using System.Collections.Generic;

namespace Cosmos.Logging.Sinks.File.Configurations {
    public class OutputOptions {
        public string Path { get; set; }
        public string Template { get; set; }
        public List<string> Navigators { get; set; }
        public RollingInterval Rolling { get; set; }
    }
}