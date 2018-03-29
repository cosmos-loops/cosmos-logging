namespace Cosmos.Abstractions.Workflow {
    public interface IDynamicForms {
        IDynamicFormsDesign Design { get; }
        string Title { get; }
    }
}