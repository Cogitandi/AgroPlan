using AgroPlan.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Core.Repositories
{
    public interface IFertilizerRepository : IRepositoryBase<Fertilizer>
    {
        Task<Fertilizer> GetIncludedFertilizer(Guid id);
    }
}
