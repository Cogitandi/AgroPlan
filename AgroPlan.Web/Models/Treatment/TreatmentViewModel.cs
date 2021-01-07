using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Treatment
{
    public class TreatmentViewModel
    {
        public Guid TreatmentId { get; set; }
        [DisplayName("Data")]
        public String Date { get; set; }
        [DisplayName("Pole")]
        public String FieldName { get; set; }
        [DisplayName("Powierzchnia")]
        public String Area { get; set; }
        [DisplayName("Rodzaj")]
        public String TreatmentKind { get; set; }
    }
}
