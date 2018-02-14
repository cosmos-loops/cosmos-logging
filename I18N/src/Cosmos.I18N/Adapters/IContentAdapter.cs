namespace Cosmos.I18N.Adapters {
    public interface IContentAdapter<out TContentFormatting> : IAdapterProcess {
        TContentFormatting OriginContent { get; }
    }
}