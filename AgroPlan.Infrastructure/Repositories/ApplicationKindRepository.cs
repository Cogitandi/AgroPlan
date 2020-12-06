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
    public class ApplicationKindRepository : RepositoryBase<ApplicationKind>, IApplicationKindRepository
    {
        public ApplicationKindRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
