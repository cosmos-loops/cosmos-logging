using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Core
{
    public class ShortcutPropertyFactoryAccessor : IPropertyFactoryAccessor
    {
        public IShortcutPropertyFactory Get() => MessageParameterProcessorCache.Get();
    }
}