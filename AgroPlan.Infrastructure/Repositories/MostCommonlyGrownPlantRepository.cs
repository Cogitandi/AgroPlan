using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Infrastructure.Repositories
{
    public class MostCommonlyGrownPlantRepository : RepositoryBase<MostCommonlyGrownPlant>, IMostCommonlyGrownPlantRepository
    {
        public MostCommonlyGrownPlantRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<MostCommonlyGrownPlant>> GetAllIncluded(ApplicationUser user)
        {
            return await _context.Set<MostCommonlyGrownPlant>()
        .Include(x => x.Plant)
        .Include(x => x.User)
        .Where(x => x.User == user)
        .ToListAsync();
        }
    }
}