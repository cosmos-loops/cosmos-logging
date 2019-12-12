using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Config file load context
    /// </summary>
    public static class ConfigLoadingContext {
        private static readonly ConcurrentDictionary<(string, string, string, int), MethodInfo> _methodCallingCache;
        private static readonly Type _stringType = typeof(string);

        static ConfigLoadingContext() {
            _methodCallingCache = new ConcurrentDictionary<(string, string, string, int), MethodInfo>();
        }

        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="type"></param>
        public static void Load(LoggingConfigurationBuilder builder, string path, FileTypes type) {
            AppendFileInternal(typeof(LoggingConfigurationBuilder), builder, path, type);
        }

        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="type"></param>
        public static void Load(IConfigurationBuilder builder, string path, FileTypes type) {
            AppendFileInternal(typeof(IConfigurationBuilder), builder, path, type);
        }

        private static void AppendFileInternal(Type callingType, object callingObj, string path, FileTypes fileTypes) {
            if (callingType is null)
                throw new ArgumentNullException(nameof(callingType));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            var method = GetMethod(callingType, fileTypes);

            if (method is null) {
                throw new InvalidOperationException($"Cannot resolve the specific FileType '{fileTypes.GetName()}'. May not refer to related dependencies.");
            }

            method.Invoke(null, new[] {callingObj, path});
        }

        private static MethodInfo GetMethod(Type firstParamType, FileTypes fileTypes) {
            var m = GetMetadata(fileTypes);
            var h = firstParamType.GetHashCode();
            var key = (m.AssemblyName, m.ClassNamePrefix, m.MethodName, h);
            if (_methodCallingCache.TryGetValue(key, out var method))
                return method;

            var assemblyName = DependencyContext.Default.GetDefaultAssemblyNames().FirstOrDefault(x => x.Name == m.AssemblyName);

            if (assemblyName == null)
                return null;

            var assembly = Assembly.Load(assemblyName);
            var fullName = $"Cosmos.Logging.Configuration.{m.ClassNamePrefix}ConfigurationBuilderExtensions";
            var clazz = assembly.GetTypes().FirstOrDefault(t => t.FullName == fullName);

            method = clazz?.GetMethod(m.MethodName, new[] {firstParamType, _stringType});

            if (method == null)
                return null;

            if (_methodCallingCache.TryAdd(key, method))
                return method;

            throw new InvalidOperationException("Cannot cache the matched method right now.");
        }

        private static (string AssemblyName, string ClassNamePrefix, string MethodName) GetMetadata(FileTypes type) {
            switch (type) {
                case FileTypes.Xml:
                    return ("Cosmos.Logging.Configuration.Xml", "Xml", "AddXmlFile");

                case FileTypes.Json:
                    return ("Cosmos.Logging.Configuration.Json", "Json", "AddJsonFile");

                case FileTypes.Yaml:
                    return ("Cosmos.Logging.Configuration.Yaml", "Yaml", "AddYamlFile");

                default:
                    throw new InvalidOperationException("Unknown type of file.");
            }
        }
    }
}