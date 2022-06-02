using COREContracts.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COREContracts.DataAccess.Repositories
{
    public interface ICoreRepository
    {
        Task<IEnumerable<CoreContract>> GetAllContractsAsync();
        Task<IEnumerable<CoreCarrier>> GetAllCarriersAsync();
        Task<CoreContract> FindContractByIdAsync(int contractId);
    }
}
