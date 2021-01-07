using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Application
    {
        public Guid Id { get; set; }

        public Season Season { get; set; }
        public ApplicationKind ApplicationKind { get; set; }

        public IEnumerable<ParcelApplication> ParcelApplications { get; set; }

        public static Application CreateApplication(IEnumerable<Field> fields, ApplicationKind applicationKind, Season season)
        {
            var parcels = new List<Parcel>();
            
            foreach(var field in fields)
            {
                foreach(var parcel in field.Parcels)
                {
                    parcels.Add(parcel);
                }
            }
            var application = new Application()
            {
                Season = season,
                ApplicationKind = applicationKind,
                ParcelApplications = parcels.Select(x => new ParcelApplication()
                {
                    Parcel = x
                }).ToList()
            };

            return application;
        }
        public static int GetApplicationArea(IEnumerable<ParcelApplication> parcelsApplication)
        {
            int area = 0;
            foreach(var parcelApplication in parcelsApplication)
            {
                if (parcelApplication.IsApplicated == true)
                    area += parcelApplication.Parcel.CultivatedArea;
            }
            return area;
        }

    }
}
