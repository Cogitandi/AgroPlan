using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class ParcelApplication
    {
        public Guid Id { get; set; }

        public Parcel Parcel { get; set; }
        public Application Application { get; set; }
        public bool IsApplicated { get; set; }
    }
}
