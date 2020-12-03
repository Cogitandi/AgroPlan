using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class ParcelCoveredByTreatment
    {
        public Guid Id { get; set; }
        
        public Parcel Parcel { get; set; }
        public Treatment Treatment { get; set; }
    }
}
