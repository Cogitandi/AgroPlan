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
    class MostCommonlyGrownPlantRepository : IMostCommonlyGrownPlantRepository
    {
        private readonly DatabaseContext _context;

        public MostCommonlyGrownPlantRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(MostCommonlyGrownPlant obj)
        {
            _context.MostCommonlyGrownPlants.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(MostCommonlyGrownPlant obj)
        {
            _context.MostCommonlyGrownPlants.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MostCommonlyGrownPlant>> GetAll()
        {
            return await _context.MostCommonlyGrownPlants.ToListAsync();
        }

        public async Task<MostCommonlyGrownPlant> GetById(Guid id)
        {
            return await _context.MostCommonlyGrownPlants
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(MostCommonlyGrownPlant obj)
        {
            _context.MostCommonlyGrownPlants.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
