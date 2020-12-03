using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Season
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public ApplicationUser User { get; set; }
    }
}
