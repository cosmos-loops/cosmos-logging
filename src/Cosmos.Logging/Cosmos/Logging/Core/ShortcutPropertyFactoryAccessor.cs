using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Core
{
    /// <summary>
    /// Shortcut property factory accessor
    /// </summary>
    public class ShortcutPropertyFactoryAccessor : IPropertyFactoryAccessor
    {
        /// <summary>
        /// Get an instance of <see cref="IShortcutPropertyFactory"/> from <see cref="MessageParameterProcessorCache"/>.
        /// </summary>
        /// <returns></returns>
        public IShortcutPropertyFactory Get() => MessageParameterProcessorCache.Get();
    }
}