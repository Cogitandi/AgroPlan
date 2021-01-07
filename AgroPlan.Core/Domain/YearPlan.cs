using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class YearPlan
    {
        public Guid Id { get; set; }

        public Field Field { get; set; }
        public Plant Plant { get; set; }
        public Season Season { get; set; }

        public static string GetPlantNameForField(IEnumerable<YearPlan> yearPlansList, Guid fieldId)
        {
            var fieldYearPlan = yearPlansList.FirstOrDefault(x=>x.Field.Id==fieldId);
            if (fieldYearPlan == null) return "Brak danych";
            return fieldYearPlan.Plant != null ? fieldYearPlan.Plant.Name : "Nie ustalono";
        }
        public static int GetAreaByPlant(IEnumerable<YearPlan> yearPlanList, Guid plantId)
        {
            int area = 0;
            foreach(var yearPlan in yearPlanList)
            {
                if (yearPlan.Plant == null || yearPlan.Plant.Id != plantId) continue;

                area += Field.GetTotalArea(yearPlan.Field.Parcels);
            }
            return area;
        }
        public static int GetAreaWithoutPlant(IEnumerable<YearPlan> yearPlanList)
        {
            int area = 0;
            foreach (var yearPlan in yearPlanList)
            {
                if (yearPlan.Plant == null)
                    area += Field.GetTotalArea(yearPlan.Field.Parcels);
            }
            return area;
        }
        public static double GetEfaArea(IEnumerable<YearPlan> yearPlanList)
        {
            double area = 0;
            foreach (var yearPlan in yearPlanList)
            {
                var plantOnField = yearPlan.Plant;
                if (plantOnField == null) continue;

                area += Field.GetTotalArea(yearPlan.Field.Parcels) * plantOnField.EfaNitrogenRate;
            }
            return area;
        }
    }
}
