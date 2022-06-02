using COREContracts.DataAccess.Models;
using COREContracts.Wrappers;
using System.Threading.Tasks;

namespace COREContracts.ViewModels
{
    public interface IContractEditViewModel
    {
        Task LoadAsync(int contractId);
        CoreContract Contract { get; }
    }
}