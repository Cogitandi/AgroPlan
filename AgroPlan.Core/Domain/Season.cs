using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Season
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public String GetName
        {
            get => StartYear + "/" + EndYear;
        }
        
        public ApplicationUser User { get; set; }
        public IEnumerable<Application> Applications { get; set; }
        public IEnumerable<YearPlan> YearPlans { get; set; }

        public static IEnumerable<YearPlan> CreateYearPlans(IEnumerable<Field> fields, Season season)
        {
            var yearplans = fields.Select(x => new YearPlan()
            {
                Field = x,
                Season = season
            }).ToList();
            return yearplans;
        }
        public static IEnumerable<Application> CreateApplications(IEnumerable<ApplicationKind> applicationKinds, IEnumerable<Field> fields, Season season)
        {
            return applicationKinds.Select(x => Application.CreateApplication(fields, x, season));
        }
        public static IEnumerable<Plant> GetPlants(IEnumerable<YearPlan> yearPlanList)
        {
            return yearPlanList
                .Where(x=>x.Plant != null)
                .Select(x=>x.Plant)
                .Distinct();
        }
    }

}
