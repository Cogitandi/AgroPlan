﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Fertilizer
{
    public class FertilizerComponentViewModel
    {

        [Display(Name = "Nazwa")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Zawartość")]
        public int PercentageContent { get; set; }
    }
}
