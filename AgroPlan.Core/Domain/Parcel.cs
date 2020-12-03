using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Parcel
    {
        public Guid Id { get; set; }
        public String Number { get; set; }
        public int CultivatedArea { get; set; }
        
        public Field Field { get; set; }
    }
}
