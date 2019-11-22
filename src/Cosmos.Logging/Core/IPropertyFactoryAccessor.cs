namespace Cosmos.Logging.Core
{
    /// <summary>
    /// To access IShortcutPropertyFactory implementation for Enricher or other extensions and sinks.
    /// </summary>
    public interface IPropertyFactoryAccessor
    {
        IShortcutPropertyFactory Get();
    }
}