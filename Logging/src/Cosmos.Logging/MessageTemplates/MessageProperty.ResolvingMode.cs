namespace Cosmos.Logging.MessageTemplates {
    public enum PropertyResolvingMode {
        Normal,        //格式化指令中不包含 s 或 S，保留原样不渲染（或使用默认渲染方案）
        Stringify,     //格式化指令中为 s，使用 ToString
        ForceStringify        //格式化指令中为 S，将对其结构进行遍历，较重，慎用
    }
}