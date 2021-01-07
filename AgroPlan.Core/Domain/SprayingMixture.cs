using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class SprayingMixture
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String ReasonForUse { get; set; }

        public ApplicationUser User { get; set; }
        public IEnumerable<SprayingComponent> SprayingComponents { get; set; }
    }
}
