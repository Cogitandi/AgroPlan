using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Field
{
    public class CreateFieldViewModel
    {
        [DisplayName("Numer]")]
        public int Number { get; set; }
        [DisplayName("Nazwa")]
        [Required]
        public String Name { get; set; }

        public IEnumerable<ParcelViewModel> Parcels { get; set; } = new List<ParcelViewModel>();
    }
}
