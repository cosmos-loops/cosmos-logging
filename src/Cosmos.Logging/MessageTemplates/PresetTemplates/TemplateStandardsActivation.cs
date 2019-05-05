namespace Cosmos.Logging.MessageTemplates.PresetTemplates {
    internal static class TemplateStandardsActivation {
        public static void RegisterToMessageTemplateCachePreheater(MessageTemplateCachePreheater preheater) {
            preheater.AddStandardsInternal(OrmTemplateStandard.Normal);
            preheater.AddStandardsInternal(OrmTemplateStandard.LongNormal);
            preheater.AddStandardsInternal(OrmTemplateStandard.SimpleSqlLog);
            preheater.AddStandardsInternal(OrmTemplateStandard.Error);
            
            preheater.AddStandardsInternal(WebTemplateStandard.Normal);
            preheater.AddStandardsInternal(WebTemplateStandard.WebLog400);
            preheater.AddStandardsInternal(WebTemplateStandard.WebLog500);
        }
    }
}