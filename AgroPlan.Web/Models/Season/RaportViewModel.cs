using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Season
{
    public class RaportViewModel
    {
        [DisplayName("Pole")]
        public String FieldName { get; set; }
        [DisplayName("Działka")]
        public String ParcelNumber { get; set; }
        [DisplayName("Powierzchnia [ha]")]
        public double ParcelArea { get; set; }
        [DisplayName("Uprawa")]
        public String PlantName { get; set; }
    }
}
