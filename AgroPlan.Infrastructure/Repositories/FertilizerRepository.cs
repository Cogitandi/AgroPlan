using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Infrastructure.Repositories
{
    public class FertilizerRepository : RepositoryBase<Fertilizer>, IFertilizerRepository
    {
        public FertilizerRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<Fertilizer> GetIncludedFertilizer(Guid id)
        {
            return await _context.Set<Fertilizer>()
                .Include(x => x.FertilizerComponents)
                .ThenInclude(y => y.ChemicalElement)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
