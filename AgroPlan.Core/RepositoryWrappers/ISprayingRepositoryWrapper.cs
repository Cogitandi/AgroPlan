using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.RepositoryWrappers
{
    public interface ISprayingRepositoryWrapper
    {
        ISprayingProductRepository SprayingProductRepository { get; }
        IContentUnitRepository ContentUnitRepository { get; }
        ISprayingComponentRepository SprayingComponentRepository { get; }
        ISprayingRepository SprayingMixtureRepository { get; }
    }
}
