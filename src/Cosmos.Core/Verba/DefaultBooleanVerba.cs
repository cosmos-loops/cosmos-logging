using System.Collections.Generic;

namespace Cosmos.Verba
{
    /// <summary>
    /// Default global boolean verba
    /// </summary>
    public class DefaultBooleanVerba : IBooleanVerba
    {
        private static DefaultBooleanVerba m_singletonInstance { get; }

        static DefaultBooleanVerba()
        {
            m_singletonInstance = new DefaultBooleanVerba();
        }

        /// <summary>
        /// Get a default global boolean verba instance
        /// </summary>
        public static DefaultBooleanVerba Instance => m_singletonInstance;

        private DefaultBooleanVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultBooleanVerba";

        /// <summary>
        /// True alias list
        /// </summary>
        public IList<string> TrueVerbaList { get; } = new List<string>() { "1", "yes", "yep", "ok" };

        /// <summary>
        /// False alias list
        /// </summary>
        public IList<string> FalseVerbaList { get; } = new List<string>() { "0", "no", "nope" };
    }
}
