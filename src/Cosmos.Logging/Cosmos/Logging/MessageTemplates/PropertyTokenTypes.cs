namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Property token type
    /// </summary>
    public enum PropertyTokenTypes {
        /// <summary>
        /// Preferences render
        /// </summary>
        PreferencesRender, // 格式形如 {$  } 的 token

        /// <summary>
        /// User defined parameter
        /// </summary>
        UserDefinedParameter, // 格式形如 {@  } 的 token

        /// <summary>
        /// Positional property
        /// </summary>
        PositionalProperty,
    }
}