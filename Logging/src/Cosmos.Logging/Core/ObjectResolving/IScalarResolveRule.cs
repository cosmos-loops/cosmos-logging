using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    public interface IScalarResolveRule {
        bool TryResolve(object value, out MessagePropertyValue result);
    }
}