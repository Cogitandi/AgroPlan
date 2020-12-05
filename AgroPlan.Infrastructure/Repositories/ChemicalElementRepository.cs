using AgroPlan.Core.Domain;
using AgroPlan.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Repositories
{
    public class ChemicalElementRepository : RepositoryBase<ChemicalElement>
    {
        public ChemicalElementRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
