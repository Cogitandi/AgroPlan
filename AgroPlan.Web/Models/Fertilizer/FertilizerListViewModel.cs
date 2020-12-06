using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Fertilizer
{
    public class FertilizerListViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Nazwa")]
        public String Name { get; set; }
    }
}
