using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Field
{
    public class EditFieldViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Numer]")]
        public int Number { get; set; }
        [Required]
        [DisplayName("Nazwa")]
        public String Name { get; set; }

        public IEnumerable<ParcelViewModel> Parcels { get; set; }
    }
}
