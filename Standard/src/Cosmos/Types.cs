using System;

namespace Cosmos {
    public static class Types {
        /// <summary>
        /// 获取类型，对可空类型进行处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type Of<T>() => Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
    }
}