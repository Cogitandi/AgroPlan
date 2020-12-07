using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Field
{
    public class ParcelViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Numer")]
        public String Number { get; set; }
        [Required]
        [Display(Name = "Powierzchnia [ar]")]
        public int Area { get; set; }
    }
}
