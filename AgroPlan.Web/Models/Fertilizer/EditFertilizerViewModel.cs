using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Fertilizer
{
    public class EditFertilizerViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public String Name { get; set; }

        public IEnumerable<FertilizerComponentViewModel> Components { get; set; } = new List<FertilizerComponentViewModel>();
    }
}
