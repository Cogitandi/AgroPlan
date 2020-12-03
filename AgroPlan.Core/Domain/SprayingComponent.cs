using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class SprayingComponent
    {
        public Guid Id { get; set; }
        public double Content { get; set; }

        public Spraying Spraying { get; set; }
        public ContentUnit ContentUnit { get; set; }
        public SprayingProduct SprayingProduct { get; set; }
    }
}
