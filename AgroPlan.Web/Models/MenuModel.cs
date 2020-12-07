using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Models
{
    public static class MenuModel
    {
        // Titles
        public static String PlantListTitle { get; } = "Lista roślin";
        public static String MostCommonlyGrownPlantListTitle { get; } = "Uprawiane rośliny";
        public static String FieldListTitle { get; } = "Moje pole";
        public static String TreatmentListTitle { get; } = "Historia zabiegów";
        public static String SprayingProductListTitle { get; } = "Środki do oprysku";
        public static String FertilizerListTitle { get; } = "Lista nawozów";
        public static String ChemicalElementListTitle { get; } = "Składniki nawozów";
        public static String TreatmentKindListTitle { get; } = "Rodzaje zabiegów";
        public static String ApplicationListTitle { get; } = "Moje wnioski";
        public static String SeasonListTitle { get; } = "Lista sezonów";
        public static String ApplicationKindListTitle { get; } = "Rodzaje wniosków";

        // Nav class
        public static string PlantListNavClass(ViewContext viewContext) => PageNavClass(viewContext, PlantListTitle);
        public static string FertilizerListNavClass(ViewContext viewContext) => PageNavClass(viewContext, FertilizerListTitle);
        public static string MostCommonlyGrownPlantNavClass(ViewContext viewContext) => PageNavClass(viewContext, MostCommonlyGrownPlantListTitle);


        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["Title"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
