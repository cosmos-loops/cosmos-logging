using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Core.Extensions {
    public static class DictionaryExtensions {
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