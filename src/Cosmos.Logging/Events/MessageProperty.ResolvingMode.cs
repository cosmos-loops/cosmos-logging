namespace Cosmos.Logging.Events {
    public enum PropertyResolvingMode {
        /// <summary>
        /// 将已知的类型和对象转换为 Scalar，将数组/集合类型转换为 Sequence
        /// </summary>
        Default,

        /// <summary>
        /// 将所有类型转换为 String，格式化指令为 S
        /// </summary>
        Stringify,

        /// <summary>
        /// 将已知类型转换为 Scalar，将对象、数组/集合转换为 Sequence 和 Structure，格式化指令为 D
        /// </summary>
        Destructure
    }
}