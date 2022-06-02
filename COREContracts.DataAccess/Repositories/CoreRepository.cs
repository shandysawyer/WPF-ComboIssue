using COREContracts.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREContracts.DataAccess.Repositories
{
public class CoreRepository : ICoreRepository
{
    private readonly Func<CoreContext> _contextFactory;

        public CoreRepository(Func<CoreContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }
        
        public async Task<IEnumerable<CoreContract>> GetAllContractsAsync()
        {
            using var context = _contextFactory();
            return await context.CoreContracts
                .AsNoTracking()
                .Include(c => c.Carrier)
                .ToListAsync();
        }

        public async Task<IEnumerable<CoreCarrier>> GetAllCarriersAsync()
        {
            using var context = _contextFactory();
            return await context.CoreCarriers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CoreContract> FindContractByIdAsync(int contractId)
        {
            using var context = _contextFactory();
            return await context.CoreContracts
                .AsNoTracking()
                .Include(c => c.Carrier)
                .Where(c => c.ContractId == contractId)
                .SingleOrDefaultAsync();
        }
    }
}
