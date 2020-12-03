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
    class FieldRepository : IFieldRepository
    {
        private readonly DatabaseContext _context;

        public FieldRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Field obj)
        {
            _context.Fields.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Field obj)
        {
            _context.Fields.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Field>> GetAll()
        {
            return await _context.Fields.ToListAsync();
        }

        public async Task<Field> GetById(Guid id)
        {
            return await _context.Fields
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Field obj)
        {
            _context.Fields.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
