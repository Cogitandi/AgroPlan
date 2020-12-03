using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Plant
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public double EfaNitrogenRate {get;set;}
    }
}
