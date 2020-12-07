using AgroPlan.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Core.Repositories
{
    public interface IMostCommonlyGrownPlantRepository : IRepositoryBase<MostCommonlyGrownPlant>
    {
        Task<IEnumerable<MostCommonlyGrownPlant>> GetAllIncluded(ApplicationUser user);
    }
}
