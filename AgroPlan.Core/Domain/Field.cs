using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Field
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public String Name { get; set; }

        public ApplicationUser User { get; set; }
        public IEnumerable<Parcel> Parcels { get; set; }
        public IEnumerable<YearPlan> YearPlans { get; set; }

        public static int GetTotalArea(IEnumerable<Parcel> parcels)
        {
            int area = 0;
            foreach (var parcel in parcels)
            {
                area += parcel.CultivatedArea;
            }
            return area;
        }

        public static int GetNumberForNewField(IEnumerable<Field> fields)
        {
            if (fields.Any())
            {
                return fields.Max(x => x.Number) + 1;
            }
            return 1;
        }
    }
}
