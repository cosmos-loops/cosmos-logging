using System;
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
        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="type"></param>
        public static void Load(LoggingConfigurationBuilder builder, string path, FileTypes type) {
            builder.Configure(b => AppendFileInternal(b, path, type));
        }

        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="type"></param>
        public static void Load(IConfigurationBuilder builder, string path, FileTypes type) {
            AppendFileInternal(builder, path, type);
        }

        private static void AppendFileInternal(IConfigurationBuilder builder, string path, FileTypes type) {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            var method = GetMethod(type);

            if (method is null) {
                throw new InvalidOperationException($"Cannot resolve the specific FileType '{type.GetName()}'. May not refer to related dependencies.");
            }

            method.Invoke(null, new object[] {builder, path});
        }

        private static MethodInfo GetMethod(FileTypes type) {
            var metadata = GetMetadata(type);
            var assemblyName = DependencyContext.Default.GetDefaultAssemblyNames().FirstOrDefault(x => x.Name == metadata.AssemblyName);

            if (assemblyName == null)
                return null;

            var assembly = Assembly.Load(assemblyName);
            var fullName = $"Cosmos.Logging.Configuration.{metadata.ClassNamePrefix}ConfigurationBuilderExtensions";
            var clazz = assembly.GetTypes().FirstOrDefault(t => t.FullName == fullName);
            return clazz?.GetMethod(metadata.MethodName);
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