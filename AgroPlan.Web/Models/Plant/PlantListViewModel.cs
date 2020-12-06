﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Plant
{
    public class PlantListViewModel
    {
        public Guid Id { get; set; }
        [Display(Name ="Nazwa")]
        public String Name { get; set; }
        [Display(Name = "Współczynnik EFA")]
        public double EfaNitrogenRate { get; set; }
    }
}
