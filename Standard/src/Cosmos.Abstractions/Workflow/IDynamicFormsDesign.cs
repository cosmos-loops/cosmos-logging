using System.Collections.Generic;

namespace Cosmos.Abstractions.Workflow
{
    public interface IDynamicFormsDesign
    {
        string Id { get; set; }
        string Name { get; set; }
        string DisplayTitle { get; set; }
        IList<IDynamicElementDesign> Elements { get; }
    }
}