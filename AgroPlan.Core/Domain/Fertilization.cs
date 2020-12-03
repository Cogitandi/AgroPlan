using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Fertilization
    {
        public Guid Id { get; set; }
        public double DosePerHa { get; set; }
        
        public Fertilizer Fertilizer { get; set; }
    }
}
