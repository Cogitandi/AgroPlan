using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext _context;

        protected RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(T obj)
        {
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return  _context.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T obj)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
