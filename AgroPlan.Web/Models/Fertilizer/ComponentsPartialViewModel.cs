using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Fertilizer
{
    public class ComponentsPartialViewModel
    {
        public IEnumerable<FertilizerComponentViewModel> Components { get; set; } = new List<FertilizerComponentViewModel>();
    }
}
