﻿using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Web.Models.Plan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("planowanie/[action]")]
    public class PlanController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IYearPlanRepository _yearPlanRepository;
        private readonly IMostCommonlyGrownPlantRepository _mostCommonlyGrownPlantRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly ISeasonRepository _seasonRepository;

        public PlanController(UserManager<ApplicationUser> userManager,
            IYearPlanRepository yearPlanRepository,
            IMostCommonlyGrownPlantRepository mostCommonlyGrownPlantRepository,
            ISeasonRepository seasonRepository,
            IPlantRepository plantRepository)
        {
            _userManager = userManager;
            _yearPlanRepository = yearPlanRepository;
            _mostCommonlyGrownPlantRepository = mostCommonlyGrownPlantRepository;
            _plantRepository = plantRepository;
            _seasonRepository = seasonRepository;
        }

        public async Task<ActionResult> Index(Guid seasonId)
        {
            var user = await _userManager.GetUserAsync(User);
            var yearPlanList = await _yearPlanRepository.FindByCondition(YearPlanInclude, x => x.Season.Id == seasonId);
            var plantList = await _mostCommonlyGrownPlantRepository.FindByCondition(dbset=>dbset.Include(x=>x.Plant),x=>x.User==user);

            var currentSeason = await _seasonRepository.GetById(seasonId);
            var startYearOfCurrentSeason = currentSeason.StartYear;
            var seasonBack1 = await _seasonRepository.FindByCondition(x => x.StartYear == startYearOfCurrentSeason-1 && x.User == user);
            var seasonBack2 = await _seasonRepository.FindByCondition(x => x.StartYear == startYearOfCurrentSeason-2 && x.User == user);
            var yearPlan1List = await _yearPlanRepository.FindByCondition(YearPlanInclude, x => x.Season == seasonBack1.FirstOrDefault());
            var yearPlan2List = await _yearPlanRepository.FindByCondition(YearPlanInclude, x => x.Season == seasonBack2.FirstOrDefault());

            var selectPlantList = plantList.Select(x => new SelectListItem()
            {
                Text = x.Plant.Name,
                Value = x.Plant.Id.ToString()
            });
            selectPlantList = selectPlantList.Append(new SelectListItem() 
            { 
                Value = Guid.Empty.ToString(),
                Text = "Nie ustalono" 
            });

            var model = yearPlanList.Select(x => new YearPlanViewModel()
            {
                Id = x.Id,
                FieldName = x.Field.Name,
                PlantId = x.Plant==null? Guid.Empty:x.Plant.Id,
                Area = Field.GetTotalArea(x.Field.Parcels),
                Plant1Name = YearPlan.GetPlantNameForField(yearPlan1List, x.Field.Id),
                Plant2Name = YearPlan.GetPlantNameForField(yearPlan2List, x.Field.Id),

            }).ToList();
            ViewBag.PlantList = selectPlantList;
            ViewBag.SeasonId = seasonId;
            ViewBag.CurrentSeasonStartYear = currentSeason.StartYear;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Guid SeasonId, IEnumerable<YearPlanViewModel> Yearplans)
        {
            var user = await _userManager.GetUserAsync(User);
            var yearPlanList = await _yearPlanRepository.FindByCondition(YearPlanInclude, x => x.Season.Id == SeasonId);
            var plantList = await _mostCommonlyGrownPlantRepository.FindByCondition(dbset => dbset.Include(x => x.Plant), x => x.User == user);

            foreach(var yearPlan in yearPlanList)
            {
                var yearPlanFromModel = Yearplans.Where(x => x.Id == yearPlan.Id).FirstOrDefault();
                yearPlan.Plant = plantList.Where(x => x.Plant.Id == yearPlanFromModel.PlantId).FirstOrDefault()?.Plant;
                await _yearPlanRepository.Update(yearPlan);
            }

            TempData["Message"] = "Zapisano pomyślnie";
            return RedirectToAction(nameof(Index), new { seasonId = SeasonId });
        }
        private Func<DbSet<YearPlan>, IQueryable<YearPlan>> YearPlanInclude =
                arg => arg.Include(x => x.Field)
                .ThenInclude(y => y.Parcels)
                .Include(x => x.Plant)
                .Include(x => x.Season);


    }
}
