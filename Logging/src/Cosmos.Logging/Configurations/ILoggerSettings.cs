using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    public interface ILoggerSettings {

        string Level { get; set; }
        string Name { get; set; }

        Dictionary<string, ILogSinkSettings> Sinks { get; set; }
        LogEventLevel GetMinimumLevel();
    }
}