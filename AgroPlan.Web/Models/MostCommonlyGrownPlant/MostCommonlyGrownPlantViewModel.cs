using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.MostCommonlyGrownPlant
{
    public class MostCommonlyGrownPlantViewModel
    {
        public IEnumerable<string> SelectedPlants { get; set; }
        public IEnumerable<SelectListItem> AvailablePlants { get; set; }
    }
}
