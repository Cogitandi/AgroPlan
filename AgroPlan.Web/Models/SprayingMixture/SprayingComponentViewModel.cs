using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.SprayingMixture
{
    public class SprayingComponentViewModel
    {
        [DisplayName("Składnik")]
        public string Name { get; set; }
        [DisplayName("Zawartość")]
        public string Content { get; set; }
        [DisplayName("Jednostka")]
        public string Unit { get; set; }
    }
}
