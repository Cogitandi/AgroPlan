using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Treatment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public String Notes { get; set; }

        public TreatmentKind TreatmentKind { get; set; }
        public SprayingMixture Spraying { get; set; }
        public Fertilization Fertilization { get; set; }
        public Sowing Sowing { get; set; }

        public IEnumerable<ParcelCoveredByTreatment> ParcelCoveredByTreatments { get; set; }
    }
}
