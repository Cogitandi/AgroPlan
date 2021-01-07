using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Treatment
{
    public class TreatmentDetailViewModel
    {
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [DisplayName("Pole")]
        public Guid FieldId { get; set; }
        public IEnumerable<ParcelForTreatmentViewModel> Parcels { get; set; }
        [DisplayName("Notatki")]
        public string Notes { get; set; }
        [DisplayName("Rodzaj zabiegu")]
        public Guid TreatmentKindId { get; set; }
        [DisplayName("Mieszanina")]
        public Guid SprayingId { get; set; }
        [DisplayName("Nawóz")]
        public Guid FertilizerId { get; set; }
        [DisplayName("Dawka na ha")]
        public double DosePerHa { get; set; }

    }
    public class ParcelForTreatmentViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Numer")]
        public String Number { get; set; }
        [DisplayName("Powierzchnia")]
        public String Area { get; set; }
    }
}
