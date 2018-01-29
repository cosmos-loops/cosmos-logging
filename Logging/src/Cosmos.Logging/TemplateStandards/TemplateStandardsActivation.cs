using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.TemplateStandards {
    internal static class TemplateStandardsActivation {
        public static void RegisterToMessageTemplateCachePreheater(MessageTemplateCachePreheater preheater) {
            preheater.AddStandardsInternal(OrmTemplateStandard.Normal);
            preheater.AddStandardsInternal(OrmTemplateStandard.Error);
        }
    }
}