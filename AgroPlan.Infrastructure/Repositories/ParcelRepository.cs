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
    class ParcelRepository : IParcelRepository
    {
        private readonly DatabaseContext _context;

        public ParcelRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Parcel obj)
        {
            _context.Parcels.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Parcel obj)
        {
            _context.Parcels.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Parcel>> GetAll()
        {
            return await _context.Parcels.ToListAsync();
        }

        public async Task<Parcel> GetById(Guid id)
        {
            return await _context.Parcels
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Parcel obj)
        {
            _context.Parcels.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
