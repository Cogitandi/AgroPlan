using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.SprayingMixture
{
    public class SprayingMixtureViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Przyczyna użycia")]
        public string ReasonForUse { get; set; }
    }
}
