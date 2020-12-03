using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class FertilizerComponent
    {
        public Guid Id { get; set; }
        public int PercentageContent { get; set; }
        public ChemicalElement ChemicalElement { get; set; }
        public Fertilizer Fertilizer { get; set; }
    }
}
