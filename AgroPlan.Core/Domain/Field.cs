using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Field
    {
        public Guid Id { get; set; }
        public String Number { get; set; }
        public String Name { get; set; }

        public ApplicationUser User { get; set; }
    }
}
