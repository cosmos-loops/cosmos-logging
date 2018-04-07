using System.ComponentModel;

namespace Cosmos.Queries {
    public enum Operator {
        [Description("等于")] Equal,

        [Description("不等于")] NotEqual,

        [Description("大于")] Greater,

        [Description("大于等于")] GreaterEqual,

        [Description("小于")] Less,

        [Description("小于等于")] LessEqual,

        [Description("头匹配")] Starts,

        [Description("尾匹配")] Ends,

        [Description("包含")] Contains
    }
}