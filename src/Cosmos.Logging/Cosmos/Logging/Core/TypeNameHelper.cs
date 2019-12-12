using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// One copy from Microsoft.Extensions.Logging
    /// </summary>
    public static class TypeNameHelper {
        private static readonly Dictionary<Type, string> BuiltInTypeNames = new Dictionary<Type, string> {
            {typeof(bool), "bool"},
            {typeof(byte), "byte"},
            {typeof(char), "char"},
            {typeof(decimal), "decimal"},
            {typeof(double), "double"},
            {typeof(float), "float"},
            {typeof(int), "int"},
            {typeof(long), "long"},
            {typeof(object), "object"},
            {typeof(sbyte), "sbyte"},
            {typeof(short), "short"},
            {typeof(string), "string"},
            {typeof(uint), "uint"},
            {typeof(ulong), "ulong"},
            {typeof(ushort), "ushort"}
        };

        public static string GetTypeDisplayName(Type type) {
            if (type.GetTypeInfo().IsGenericType) {
                var parts = type.GetGenericTypeDefinition().FullName.Split('+');
                for (var i = 0; i < parts.Length; i++) {
                    var partName = parts[i];
                    var backTickIndex = partName.IndexOf('`');
                    if (backTickIndex >= 0) {
                        partName = partName.Substring(0, backTickIndex);
                    }

                    parts[i] = partName;
                }

                return string.Join(".", parts);
            }

            if (BuiltInTypeNames.ContainsKey(type)) {
                return BuiltInTypeNames[type];
            }

            var fullName = type.FullName;

            if (type.IsNested) {
                fullName = fullName.Replace('+', '.');
            }

            return fullName;
        }
    }
}