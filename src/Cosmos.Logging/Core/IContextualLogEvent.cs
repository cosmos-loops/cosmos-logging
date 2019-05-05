using System.Collections.Generic;

namespace Cosmos.Logging.Core {
    public interface IContextualLogEvent {
        IReadOnlyList<string> Tags { get; }
    }
}