using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public interface ILoggingOptions {

        string Level { get; set; }
        string Name { get; set; }

        Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }
        LogEventLevel GetMinimumLevel();
    }
}