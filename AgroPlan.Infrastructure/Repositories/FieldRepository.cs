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
    public class FieldRepository : RepositoryBase<FieldRepository>
    {
        public FieldRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
