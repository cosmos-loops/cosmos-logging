using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Logging.Renders {
    internal static class PreferencesRenderersScanner {
        private static readonly Type PreferencesSinkRendererType = typeof(IPreferencesSinkRenderer);
        private static readonly Type PreferencesRendererType = typeof(IPreferencesRenderer);

        public static void Given(IEnumerable<Type> types) {
            Core(FilterPreferencesRendererTypes(types));
        }

        public static void Scan() {
            Core(GetAllPreferencesRendererTypes());
        }

        private static void Core(IEnumerable<Type> givenTypes) {
            foreach (var type in givenTypes) {
                var reflector = type.GetReflector();
                var sinkMode = PreferencesSinkRendererType.IsAssignableFrom(type);
                var declareInfos = reflector.GetCustomAttributes<RendererAttribute>().Where(x => !string.IsNullOrWhiteSpace(x.Name)).ToList();
                var constructorInfo = type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any());
                if (constructorInfo == null) throw new InvalidOperationException("Preferences renderer must has a args-less constructor.");
                var instance = constructorInfo.GetReflector().Invoke();
                if (declareInfos.Any()) {
                    if (sinkMode && instance is IPreferencesSinkRenderer sinkRenderer) {
                        PreferencesRenderersManager.AddPreferencesSinkRenderer(declareInfos.Select(x => (x.SinkPrefix, x.Name)).ToList(), sinkRenderer);
                    } else if (instance is IPreferencesRenderer renderer) {
                        PreferencesRenderersManager.AddPreferencesRenderer(declareInfos.Select(x => x.Name).ToList(), renderer);
                    } else {
                        throw new InvalidOperationException("Unknown renderer.");
                    }
                } else {
                    if (sinkMode && instance is IPreferencesSinkRenderer sinkRenderer) {
                        PreferencesRenderersManager.AddPreferencesSinkRenderer(sinkRenderer);
                    } else if (instance is IPreferencesRenderer renderer) {
                        PreferencesRenderersManager.AddPreferencesRenderer(renderer);
                    } else {
                        throw new InvalidOperationException("Unknown renderer.");
                    }
                }
            }
        }

        private static IEnumerable<Type> GetAllPreferencesRendererTypes() {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Concat(GetAllUnlinkedAssemblies());
            foreach (var assembly in assemblies) {
                if (NeedToIgnore(assembly)) {
                    continue;
                }

                var types = assembly.GetExportedTypes()
                    .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && PreferencesRendererType.IsAssignableFrom(t))
                    .Where(x => !x.GetReflector().IsDefined<NonScanRendererAttribute>());
                foreach (var type in types)
                    yield return type;
            }
        }

        private static IEnumerable<Assembly> GetAllUnlinkedAssemblies() {
            var directoryRoot = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directoryRoot.GetFiles("Cosmos.Logging.Renderers.*.dll", SearchOption.AllDirectories);
            foreach (var file in files) {
                yield return Assembly.LoadFrom(file.FullName);
            }
        }

        private static IEnumerable<Type> FilterPreferencesRendererTypes(IEnumerable<Type> types) {
            var matchedTypes = types
                .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && PreferencesRendererType.IsAssignableFrom(t))
                .Where(x => !x.GetReflector().IsDefined<NonScanRendererAttribute>());
            foreach (var type in matchedTypes)
                yield return type;
        }

        private const string SkipAssemblies =
            "^System|^Mscorlib|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted";

        private static bool NeedToIgnore(Assembly assembly) {
            return Regex.IsMatch(assembly.FullName, SkipAssemblies, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
    }
}