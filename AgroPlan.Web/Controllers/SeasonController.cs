using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Web.Models.Season;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("wnioski/[action]")]
    public class SeasonController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFieldRepository _fieldRepository;
        private readonly ISeasonRepository _seasonRepository;

        public SeasonController(
            UserManager<ApplicationUser> userManager,
            IFieldRepository fieldRepository,
            ISeasonRepository seasonRepository)
        {
            _userManager = userManager;
            _fieldRepository = fieldRepository;
            _seasonRepository = seasonRepository;
        }

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

        public async Task<ActionResult> Manage(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _seasonRepository.FindByCondition(x => x.User == user);

            var model = list.Select(x => new ManageViewModel()
            {
                Id = x.Id,
                Name = x.GetName

            }).FirstOrDefault();
            return View(model);
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
            var fields = await _fieldRepository.FindByCondition(x => x.User == user);

            var season = new Season()
            {
                User = user,
                StartYear = model.StartYear,
                EndYear = model.StartYear + 1
            };

            var yearPlans = Season.CreateYearPlans(fields, season);
            season.YearPlans = yearPlans;

            await _seasonRepository.Add(season);
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
    }
}
