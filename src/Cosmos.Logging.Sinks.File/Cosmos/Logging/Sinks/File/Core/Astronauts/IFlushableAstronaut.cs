namespace Cosmos.Logging.Sinks.File.Core.Astronauts {
    /// <summary>
    /// Interface for flushable astronaut
    /// </summary>
    public interface IFlushableAstronaut {
        /// <summary>
        /// Flush to disk
        /// </summary>
        void FlushToDisk();

        /// <summary>
        /// Close file
        /// </summary>
        void CloseFile();
    }
}