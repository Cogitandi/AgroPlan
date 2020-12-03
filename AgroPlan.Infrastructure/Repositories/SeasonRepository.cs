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
    class SeasonRepository : ISeasonRepository
    {
        private readonly DatabaseContext _context;

        public SeasonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Season obj)
        {
            _context.Seasons.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Season obj)
        {
            _context.Seasons.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Season>> GetAll()
        {
            return await _context.Seasons.ToListAsync();
        }

        public async Task<Season> GetById(Guid id)
        {
            return await _context.Seasons
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Season obj)
        {
            _context.Seasons.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
