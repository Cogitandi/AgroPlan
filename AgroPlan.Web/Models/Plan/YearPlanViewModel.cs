using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models.Plan
{
    public class YearPlanViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Nazwa")]
        public String FieldName { get; set; }
        private double area;
        [DisplayName("Powierzchnia [ha]")]
        public double Area
        {
            get { return area / 100; }
            set { area = value; }
        }
        [DisplayName("Uprawa")]
        public Guid PlantId { get; set; }
    }
}
