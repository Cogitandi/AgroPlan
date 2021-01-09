using AgroPlan.Core.Domain;
using AgroPlan.Core.RepositoryWrappers;
using AgroPlan.Web.Models.SprayingMixture;
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
    public class SprayingMixtureController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISprayingRepositoryWrapper _sprayingRepositoryWrapper;

        public SprayingMixtureController(UserManager<ApplicationUser> userManager, ISprayingRepositoryWrapper sprayingRepositoryWrapper)
        {
            _userManager = userManager;
            _sprayingRepositoryWrapper = sprayingRepositoryWrapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var sprayingMixtures = await _sprayingRepositoryWrapper.SprayingMixtureRepository.FindByCondition(x => x.User == user);
            var model = sprayingMixtures.Select(x => new SprayingMixtureViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ReasonForUse = x.ReasonForUse,
            });

            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var sprayingMixtureList = await _sprayingRepositoryWrapper.SprayingMixtureRepository.FindByCondition(SprayingMixtureInclude,x => x.Id==id);
            var sprayingMixture = sprayingMixtureList.FirstOrDefault();
            if(sprayingMixture == null)
            {
                return NotFound();
            }

            var model = new SprayingMixtureDetailsViewModel()
            {
                Name = sprayingMixture.Name,
                ReasonForUse = sprayingMixture.ReasonForUse,
                Components = sprayingMixture.SprayingComponents.Select(x=>new SprayingComponentViewModel()
                {
                    Name = x.SprayingProduct.Name,
                    Content = x.Content.ToString(),
                    Unit = x.ContentUnit.ShortName,
                })
            };

            return PartialView(model);
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SprayingMixtureDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.GetUserAsync(User);

            var sprayingComponents = new List<SprayingComponent>();
            foreach(var component in model.Components)
            {
                var item = new SprayingComponent()
                {
                    Content = Double.Parse(component.Content),
                    ContentUnit = await _sprayingRepositoryWrapper.ContentUnitRepository.GetById(Guid.Parse(component.Unit)),
                    SprayingProduct = await _sprayingRepositoryWrapper.SprayingProductRepository.GetById(Guid.Parse(component.Name)),
                };
                sprayingComponents.Add(item);
            }

            var sprayingMixture = new SprayingMixture()
            {
                Name = model.Name,
                ReasonForUse = model.ReasonForUse,
                SprayingComponents = sprayingComponents,
                User = user,
                
            };
            await _sprayingRepositoryWrapper.SprayingMixtureRepository.Add(sprayingMixture);
            
            TempData["Message"] = "Dodano nową mieszaninę: " + sprayingMixture.Name;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComponent(SprayingMixtureDetailsViewModel model)
        {
            model.Components = model.Components.Append(new SprayingComponentViewModel());
            AddSprayingMixtureComponentData();
            return PartialView("_SprayingComponents", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComponent(SprayingMixtureDetailsViewModel model, int index)
        {
            var toDelete = model.Components.ElementAt(index);
            model.Components = model.Components.Where(x => x != toDelete);
            AddSprayingMixtureComponentData();
            ModelState.Clear();
            return PartialView("_SprayingComponents", model);
        }
        private void AddSprayingMixtureComponentData()
        {
            var sprayingProducts = _sprayingRepositoryWrapper.SprayingProductRepository.GetAll();
            var contentUnits = _sprayingRepositoryWrapper.ContentUnitRepository.GetAll();
            ViewBag.sprayingProducts = sprayingProducts.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            ViewBag.contentUnits = contentUnits.Select(x => new SelectListItem()
            {
                Text = x.ShortName,
                Value = x.Id.ToString(),
            });
        }
        private Func<DbSet<SprayingMixture>, IQueryable<SprayingMixture>> SprayingMixtureInclude =
                arg => arg
                .Include(x => x.SprayingComponents)
                    .ThenInclude(y => y.ContentUnit)
                .Include(x => x.SprayingComponents)
                    .ThenInclude(x => x.SprayingProduct);
    }
}
