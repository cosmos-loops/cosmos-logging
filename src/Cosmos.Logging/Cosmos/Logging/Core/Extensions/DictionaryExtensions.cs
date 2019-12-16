using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Core.Extensions {
    /// <summary>
    /// Extensions of dictionary
    /// </summary>
    public static class DictionaryExtensions {
        /// <summary>
        /// Merge
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="keyConvertFunc"></param>
        /// <param name="valueConvertFunc"></param>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        public static void Merge<TKey1, TValue1, TKey2, TValue2>(this Dictionary<TKey1, TValue1> target, Dictionary<TKey2, TValue2> source,
            Func<TKey2, TKey1> keyConvertFunc, Func<TValue2, TValue1> valueConvertFunc) {
            if (target == null) return;
            if (source == null) return;
            if (keyConvertFunc == null) return;
            if (valueConvertFunc == null) return;
            foreach (var item in source) {
                var k = keyConvertFunc(item.Key);
                if (target.ContainsKey(k)) continue;
                target.Add(k, valueConvertFunc(item.Value));
            }
        }

        /// <summary>
        /// Merge and over write
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="keyConvertFunc"></param>
        /// <param name="valueConvertFunc"></param>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        public static void MergeAndOverWrite<TKey1, TValue1, TKey2, TValue2>(this Dictionary<TKey1, TValue1> target, Dictionary<TKey2, TValue2> source,
            Func<TKey2, TKey1> keyConvertFunc, Func<TValue2, TValue1> valueConvertFunc) {
            if (target == null) return;
            if (source == null) return;
            if (keyConvertFunc == null) return;
            if (valueConvertFunc == null) return;
            foreach (var item in source) {
                var k = keyConvertFunc(item.Key);
                var v = valueConvertFunc(item.Value);
                if (target.ContainsKey(k)) {
                    target[k] = v;
                } else {
                    target.Add(k, v);
                }
            }
        }

    }
}