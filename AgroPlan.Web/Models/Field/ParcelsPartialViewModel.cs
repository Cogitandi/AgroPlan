using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Field
{
    public class ParcelsPartialViewModel
    {
        public IEnumerable<ParcelViewModel> Parcels { get; set; } = new List<ParcelViewModel>();
    }
}
