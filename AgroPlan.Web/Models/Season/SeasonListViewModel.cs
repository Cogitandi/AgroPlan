using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Season
{
    public class SeasonListViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Sezon")]
        public String Name { get; set; }
    }
}
