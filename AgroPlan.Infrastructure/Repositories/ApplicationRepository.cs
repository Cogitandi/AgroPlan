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
    class ApplicationRepository : IApplicationRepository
    {
        private readonly DatabaseContext _context;

        public ApplicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Application obj)
        {
            _context.Applications.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Application obj)
        {
            _context.Applications.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> GetById(Guid id)
        {
            return await _context.Applications
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Application obj)
        {
            _context.Applications.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
