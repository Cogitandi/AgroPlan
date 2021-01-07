using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Web.Models.Season;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("sezon/[action]")]
    public class SeasonController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFieldRepository _fieldRepository;
        private readonly IYearPlanRepository _yearPlanRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IApplicationKindRepository _applicationKindRepository;
        private readonly IApplicationRepository _applicationRepository;


        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _seasonRepository.FindByCondition(x => x.User == user);

            var model = list.Select(x => new SeasonListViewModel()
            {
                Id = x.Id,
                Name = x.GetName

            });
            return View(model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        public ActionResult Manage(Guid id)
        {
            return View((Object)id.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSeasonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.GetUserAsync(User);
            var fields = await _fieldRepository.FindByCondition(dbSet=>dbSet.Include(x=>x.Parcels),x => x.User == user);
            var applicationKinds = await _applicationKindRepository.FindByCondition(x=> true);

            var season = new Season()
            {
                User = user,
                StartYear = model.StartYear,
                EndYear = model.StartYear + 1
            };

            var yearPlans = Season.CreateYearPlans(fields, season);
            var applications = Season.CreateApplications(applicationKinds, fields, season);
            season.YearPlans = yearPlans;

            await _seasonRepository.Add(season);
            foreach(var application in applications)
            {
                await _applicationRepository.Add(application);
            }
            
            TempData["Message"] = "Dodano nowy sezon: " + season.GetName;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task Delete(Guid id)
        {
            var seasons = await _seasonRepository.FindByCondition(x => x.Id == id);
            var season = seasons.FirstOrDefault();
            await _seasonRepository.Delete(season);
            TempData["Message"] = "Sezon " + season.GetName + " został usunięty";
            return;
        }
        public async Task<IActionResult> Summary(Guid SeasonId)
        {
            List<SummaryViewModel> model = new List<SummaryViewModel>();
            var yearPlanList = await _yearPlanRepository.FindByCondition(YearPlanInclude, x => x.Season.Id == SeasonId);
            var plantList = Season.GetPlants(yearPlanList);

            #region Plants
            var plantsSummary = plantList.Select(x => new SummaryViewModel()
            {
                Name = x.Name,
                Value = YearPlan.GetAreaByPlant(yearPlanList, x.Id)/100.0 + " ha",
            });
            var withoutPlantArea = new SummaryViewModel()
            {
                Name = "Nie zaplanowano",
                Value = YearPlan.GetAreaWithoutPlant(yearPlanList) / 100.0 + " ha",
            };
            #endregion

            var EfaArea = new SummaryViewModel()
            {
                Name = "EFA",
                Value = YearPlan.GetEfaArea(yearPlanList) + " ha",
            };

            #region Applications
            var applicationList = await _applicationRepository.FindByCondition(ApplicationInclude, x => x.Season.Id == SeasonId);
            var ApplicationsSummary = applicationList.Select(x => new SummaryViewModel()
            {
                Name = "wniosek - " + x.ApplicationKind.Name,
                Value = Application.GetApplicationArea(x.ParcelApplications)/100.0 + " ha",
            });
            #endregion

            model.AddRange(plantsSummary);
            model.Add(EfaArea);
            model.AddRange(ApplicationsSummary);
            if (withoutPlantArea.Value != 0 + " ha")
            {
                model.Add(withoutPlantArea);
            }
            
            return View(model);
        }
        public async Task<IActionResult> Raport(Guid SeasonId)
        {
            var yearPlans = await _yearPlanRepository.FindByCondition(YearPlanInclude, x => x.Season.Id == SeasonId);
            var parcels = yearPlans.SelectMany(x => x.Field.Parcels);
            var model = parcels.Select(x => new RaportViewModel()
            {
                FieldName = x.Field.Name +" ["+Field.GetTotalArea(x.Field.Parcels)/100.0+" ha]",
                ParcelNumber = x.Number,
                ParcelArea = x.CultivatedArea/100.0,
                PlantName = YearPlan.GetPlantNameForField(yearPlans, x.Field.Id),
            });

            return View(model);
        }
        // Validation
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> UniqueSeason(int startYear)
        {
            var user = await _userManager.GetUserAsync(User);
            var fields = await _seasonRepository.FindByCondition(x => x.User == user && x.StartYear == startYear);

                if (fields.Any())
                {
                    return Json($"Posiadasz już sezon na ten rok");
                }
            return Json(true);
        }

        private Func<DbSet<Season>, IQueryable<Season>> includeSeasonUser =
                arg => arg.Include(x => x.User);



        public SeasonController(UserManager<ApplicationUser> userManager, IFieldRepository fieldRepository, IYearPlanRepository yearPlanRepository, ISeasonRepository seasonRepository, IApplicationKindRepository applicationKindRepository, IApplicationRepository applicationRepository)
        {
            _userManager = userManager;
            _fieldRepository = fieldRepository;
            _yearPlanRepository = yearPlanRepository;
            _seasonRepository = seasonRepository;
            _applicationKindRepository = applicationKindRepository;
            _applicationRepository = applicationRepository;
        }

        private Func<DbSet<YearPlan>, IQueryable<YearPlan>> YearPlanInclude =
                arg => arg.Include(x => x.Field)
                .ThenInclude(y => y.Parcels)
                .Include(x => x.Plant)
                .Include(x => x.Season);
        private Func<DbSet<Application>, IQueryable<Application>> ApplicationInclude =
                arg => arg.Include(x=>x.ApplicationKind)
                .Include(x => x.Season)
                .Include(x => x.ParcelApplications)
                .ThenInclude(x => x.Parcel);
    }
}
