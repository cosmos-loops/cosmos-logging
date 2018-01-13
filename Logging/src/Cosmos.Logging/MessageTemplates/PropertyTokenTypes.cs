namespace Cosmos.Logging.MessageTemplates {
    public enum PropertyTokenTypes {
        PreferencesRender,        // 格式形如 {$  } 的 token
        UserDefinedParameter,     // 格式形如 {@  } 的 token
    }
}