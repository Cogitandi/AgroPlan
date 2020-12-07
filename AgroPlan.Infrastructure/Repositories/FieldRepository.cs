using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Infrastructure.Repositories
{
    public class FieldRepository : RepositoryBase<Field>, IFieldRepository
    {
        public FieldRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public IEnumerable<Field> GetIncluded(Expression<Func<Field, bool>> expression)
        {
            return _context
                .Set<Field>()
                .Include(x => x.Parcels)
                .Where(expression);
        }
    }
}
