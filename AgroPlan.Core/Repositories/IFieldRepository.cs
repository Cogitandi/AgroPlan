using AgroPlan.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Core.Repositories
{
    public interface IFieldRepository : IRepositoryBase<Field>
    {
        IEnumerable<Field> GetIncluded(Expression<Func<Field, bool>> expression);
    }
}
