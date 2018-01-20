using System;
using System.Collections.Generic;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Events;
using EnumsNET;

namespace Cosmos.Logging.Settings {
    public class LoggingSettings : ILoggerSettings {

        private static LoggingSettings DefaultSetingsCache = new LoggingSettings();
        public static LoggingSettings Defaults => DefaultSetingsCache;

        private readonly List<Type> _additionalScalarTypes = new List<Type>();
        private readonly List<IDestructureResolveRule> _additionalDestructureResolveRules = new List<IDestructureResolveRule>();
        private int _maxLengthOfString = int.MaxValue;
        private int _maxLevelOfNestLevelLimited = 10;
        private int _maxLoopCountForCollection = int.MaxValue;

        public string Level { get; set; } = Enums.GetName(LogEventLevel.Off);
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, ILogSinkSettings> Sinks { get; set; }

        public LogEventLevel GetMinimumLevel() {
            var member = Enums.GetMember<LogEventLevel>(Level, true, EnumFormat.Description);
            return member?.Value ?? LogEventLevel.Off;
        }

        public DestructureConfiguration GetDestructure() {
            //todo 临时代码
            return new DestructureConfiguration {
                MaximumLengthOfString = _maxLengthOfString,
                MaximumLevelOfNestLevelLimited = _maxLevelOfNestLevelLimited,
                MaximumLoopCountForCollection = _maxLoopCountForCollection,
                AdditionalDestructureResolveRules = _additionalDestructureResolveRules,
                AdditionalScalarTypes = _additionalScalarTypes
            };
        }
    }
}