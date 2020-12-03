using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgroPlan.Infrastructure.Data;

namespace AgroPlan.Infrastructure.Repositories
{
    public class ApplicationKindRepository : IApplicationKindRepository
    {
        private readonly DatabaseContext _context;

        public ApplicationKindRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(ApplicationKind obj)
        {
            _context.ApplicationKinds.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ApplicationKind obj)
        {
            _context.ApplicationKinds.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationKind>> GetAll()
        {
            return await _context.ApplicationKinds.ToListAsync();
        }

        public async Task<ApplicationKind> GetById(Guid id)
        {
            return await _context.ApplicationKinds
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(ApplicationKind obj)
        {
            _context.ApplicationKinds.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
