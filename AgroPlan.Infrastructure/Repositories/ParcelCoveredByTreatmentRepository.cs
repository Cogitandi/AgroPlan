using AgroPlan.Core.Domain;
using AgroPlan.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Repositories
{
    public class ParcelCoveredByTreatmentRepository : RepositoryBase<ParcelCoveredByTreatment>
    {
        public ParcelCoveredByTreatmentRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
