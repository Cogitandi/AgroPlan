using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Core.Repositories
{
    public interface IRepositoryBase<T> where T: class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> FindByCondition( Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindByCondition(Func<DbSet<T>, IQueryable<T>> customInclude, Expression<Func<T, bool>> expression);
        Task<T> GetById(Guid id);
        Task Add(T obj);
        Task Delete(T obj);
        Task Update(T obj);
    }
}
