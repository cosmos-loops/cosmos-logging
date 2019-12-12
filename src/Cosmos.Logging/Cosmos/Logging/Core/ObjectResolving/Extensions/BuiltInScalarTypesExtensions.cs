using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Core.ObjectResolving.Extensions {
    internal static class BuiltInScalarTypesExtensions {
        static readonly HashSet<Type> Values = new HashSet<Type> {
            typeof(bool),
            typeof(char),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(string),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid),
            typeof(Uri)
        };

        public static bool CheckType(Type type) => Values.Contains(type);

        public static bool IsScalarType(this Type type) => CheckType(type);

        public static IEnumerable<Type> GetAllScalarTypes(this IEnumerable<Type> additionalScalarTypes) => Values.Concat(additionalScalarTypes);
    }
}