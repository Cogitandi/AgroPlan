using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Field
{
    public class FieldListViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Numer")]
        public int Number { get; set; }
        [DisplayName("Nazwa")]
        public String Name { get; set; }

        private double area;
        [DisplayName("Powierzchnia [ha]")]
        public double Area
        {
            get { return area/100; }
            set { area = value; }
        }

    }
}
