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
    class PlantRepository : IPlantRepository
    {
        private readonly DatabaseContext _context;

        public PlantRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Plant obj)
        {
            _context.Plants.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Plant obj)
        {
            _context.Plants.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Plant>> GetAll()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetById(Guid id)
        {
            return await _context.Plants
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Plant obj)
        {
            _context.Plants.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
