using System.Text;

namespace Cosmos.Logging.Sinks.File.Core.Astronauts {
    /// <summary>
    /// Interface for Astronaut
    /// </summary>
    public interface IAstronaut {
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="stringBuilder"></param>
        void Save(StringBuilder stringBuilder);
    }
}