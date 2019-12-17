using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AspectCore.Extensions.Reflection;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving.Extensions {
    internal static class TypeFeelerExtensions {
        public static bool TryResolve(this IScalarResolveRule[] rules, object value, out MessagePropertyValue result) {
            result = null;
            foreach (var rule in rules) {
                if (rule.TryResolve(value, out result)) {
                    return true;
                }
            }

            return false;
        }

        public static bool TryResolve(this IDestructureResolveRule[] rules, object value, PropertyResolvingMode mode,
            NestParameterResolver nest, out MessagePropertyValue result) {
            result = null;
            if (mode == PropertyResolvingMode.Destructure) {
                foreach (var rule in rules) {
                    if (rule.TryResolve(value, nest, out result)) {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// One copy from serilog
        /// Author: tsimbalar and nblumhardt
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsCompilerGeneratedType(this Type type) {
            var typeInfo = type.GetTypeInfo();
            var typeName = type.Name;
            //C# Anonymous types always start with "<>" and VB's start with "VB$"
            return typeInfo.IsGenericType && typeInfo.IsSealed && typeInfo.IsNotPublic && type.Namespace == null
                   && (typeName[0] == '<' || (typeName.Length > 2 && typeName[0] == 'V' && typeName[1] == 'B' && typeName[2] == '$'));
        }

        /// <summary>
        /// One copy from Serilog.
        /// Author: Simon Cropp
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static IEnumerable<PropertyInfo> GetPropertiesRecursive(this Type type) {
            var touchedNames = new HashSet<string>();
            var currentType = type;
            while (currentType != typeof(object)) {

                var properties = currentType.GetTypeInfo().DeclaredProperties
                    .Where(p => p.CanRead &&
                                p.GetMethod.IsPublic &&
                                !p.GetMethod.IsStatic &&
                                (p.Name != "Item" || p.GetIndexParameters().Length == 0) &&
                                !touchedNames.Contains(p.Name));

                foreach (var property in properties) {
                    touchedNames.Add(property.GetReflector().Name);
                    yield return property;
                }

                currentType = currentType?.BaseType;
            }
        }
    }
}