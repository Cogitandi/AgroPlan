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
    class ParcelApplicationRepository : IParcelApplicationRepository
    {
        private readonly DatabaseContext _context;

        public ParcelApplicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(ParcelApplication obj)
        {
            _context.ParcelApplications.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ParcelApplication obj)
        {
            _context.ParcelApplications.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ParcelApplication>> GetAll()
        {
            return await _context.ParcelApplications.ToListAsync();
        }

        public async Task<ParcelApplication> GetById(Guid id)
        {
            return await _context.ParcelApplications
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(ParcelApplication obj)
        {
            _context.ParcelApplications.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
