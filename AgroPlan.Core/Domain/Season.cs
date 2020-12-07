﻿using System;
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
    }

}
