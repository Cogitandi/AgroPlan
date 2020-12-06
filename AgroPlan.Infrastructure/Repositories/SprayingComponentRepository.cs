﻿using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Repositories
{
    public class SprayingComponentRepository : RepositoryBase<SprayingComponent>, ISprayingComponentRepository
    {
        public SprayingComponentRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
