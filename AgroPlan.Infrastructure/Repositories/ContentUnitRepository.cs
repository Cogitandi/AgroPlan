using AgroPlan.Core.Domain;
using AgroPlan.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Repositories
{
    public class ContentUnitRepository : RepositoryBase<ContentUnit>
    {
        public ContentUnitRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
