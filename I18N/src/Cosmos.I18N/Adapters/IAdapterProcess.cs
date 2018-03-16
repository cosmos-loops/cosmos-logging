using System.Threading.Tasks;

namespace Cosmos.I18N.Adapters {
    public interface IAdapterProcess {
        bool Process();
        Task<bool> ProcessAsync();
    }
}