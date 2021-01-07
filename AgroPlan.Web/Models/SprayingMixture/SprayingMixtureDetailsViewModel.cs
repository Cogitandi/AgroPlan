using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.SprayingMixture
{
    public class SprayingMixtureDetailsViewModel
    {
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Przyczyna użycia")]
        public string ReasonForUse { get; set; }

        public IEnumerable<SprayingComponentViewModel> Components { get; set; } = new List<SprayingComponentViewModel>();
    }
}
