using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Season
{
    public class CreateSeasonViewModel
    {
        [Required]
        [DisplayName("Rok rozpoczęcia")]
        [Remote(action: "UniqueSeason", controller: "Season")]
        public int StartYear { get; set; }
    }
}
