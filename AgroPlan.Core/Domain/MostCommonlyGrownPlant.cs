using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class MostCommonlyGrownPlant
    {
        public Guid Id { get; set; }

        public ApplicationUser User { get; set; }
        public Plant Plant { get; set; }
    }
}
