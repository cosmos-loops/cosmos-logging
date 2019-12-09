namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Three value boolean
    /// </summary>
    public static class ThreeValuedBoolean {
        /// <summary>
        /// True
        /// </summary>
        public static bool? True => true;

        /// <summary>
        /// False
        /// </summary>
        public static bool? False => false;

        /// <summary>
        /// Default
        /// </summary>
        public static bool? Default => null;
    }
}