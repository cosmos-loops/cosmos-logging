using System.Collections.Generic;

namespace Cosmos.Verba.Boolean
{
    /// <summary>
    /// Interface for boolean verba
    /// </summary>
    public interface IBooleanVerba
    {
        /// <summary>
        /// Verba name
        /// </summary>
        string VerbaName { get; }

        /// <summary>
        /// True alias list
        /// </summary>
        IList<string> TrueVerbaList { get; }

        /// <summary>
        /// False alias list
        /// </summary>
        IList<string> FalseVerbaList { get; }
    }
}
