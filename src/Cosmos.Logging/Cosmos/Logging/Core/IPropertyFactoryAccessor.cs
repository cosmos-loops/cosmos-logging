namespace Cosmos.Logging.Core {
    /// <summary>
    /// To access IShortcutPropertyFactory implementation for Enricher or other extensions and sinks.
    /// </summary>
    public interface IPropertyFactoryAccessor {
        /// <summary>
        /// Get an instance of <see cref="IShortcutPropertyFactory"/>.
        /// </summary>
        /// <returns></returns>
        IShortcutPropertyFactory Get();
    }
}