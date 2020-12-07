using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Application
{
    public class ApplicationDetailViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Nazwa pola")]
        public String FieldName { get; set; }
        [DisplayName("Numer działki")]
        public String ParcelNumber { get; set; }
        [DisplayName("Powierzchnia [ar]")]
        public int Area { get; set; }
        [DisplayName("Kwalifikacja do wniosku")]
        public bool Checked { get; set; }
    }
}
