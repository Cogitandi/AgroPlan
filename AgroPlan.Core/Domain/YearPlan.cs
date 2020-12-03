using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class YearPlan
    {
        public Guid Id { get; set; }

        public Field Field { get; set; }
        public Plant Plant { get; set; }
        public Season Season { get; set; }
    }
}
