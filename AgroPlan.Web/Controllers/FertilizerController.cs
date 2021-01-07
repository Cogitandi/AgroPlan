using AgroPlan.Core.Domain;
using AgroPlan.Core.RepositoryWrappers;
using AgroPlan.Web.Models.Fertilizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("nawozy/[action]")]
    public class FertilizerController : Controller
    {
        private readonly IFertilizerRepositoryWrapper _fertilizerRepositoryWrapper;

        public FertilizerController(IFertilizerRepositoryWrapper fertilizerRepositoryWrapper)
        {
            _fertilizerRepositoryWrapper = fertilizerRepositoryWrapper;
        }

        public ActionResult List()
        {
            var list = _fertilizerRepositoryWrapper.FertilizerRepository.GetAll();

            var model = list.Select(x => new FertilizerListViewModel()
            {
                Id = x.Id,
                Name = x.Name
            });
            return View(model);
        }

        public ActionResult Index()
        {
            var list = _fertilizerRepositoryWrapper.FertilizerRepository.GetAll();

            var model = list.Select(x => new FertilizerListViewModel()
            {
                Id = x.Id,
                Name = x.Name
            });
            return View(model);
        }

        public ActionResult Create()
        {
            AddChemicalElementList();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFertilizerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var components = model.Components.Select(x => new FertilizerComponent()
            {
                ChemicalElement = _fertilizerRepositoryWrapper.ChemicalElementRepository.GetById(x.Id).Result,
                PercentageContent = x.PercentageContent
            }).ToList();

            var fertilizer = new Fertilizer()
            {
                Name = model.Name,
                FertilizerComponents = components
            };

            await _fertilizerRepositoryWrapper.FertilizerRepository.Add(fertilizer);
            TempData["Message"] = "Dodano nowy nawóz: "+ fertilizer.Name;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComponent(ComponentsPartialViewModel model)
        {
            model.Components = model.Components.Append(new FertilizerComponentViewModel());
            AddChemicalElementList();
            return PartialView("_Components", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComponent(ComponentsPartialViewModel model,int index)
        {
            var toDelete = model.Components.ElementAt(index);
            model.Components = model.Components.Where(x => x != toDelete);
            AddChemicalElementList();
            ModelState.Clear();
            return PartialView("_Components", model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var fertilizer = await _fertilizerRepositoryWrapper.FertilizerRepository.GetIncludedFertilizer(id);

            var model = new EditFertilizerViewModel()
            {
                Id = fertilizer.Id,
                Name = fertilizer.Name,
                Components = fertilizer.FertilizerComponents.Select(x => new FertilizerComponentViewModel()
                {
                    Id = x.ChemicalElement.Id,
                    PercentageContent = x.PercentageContent
                })
            };
            AddChemicalElementList();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditFertilizerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var components = model.Components.Select(x => new FertilizerComponent()
            {
                ChemicalElement = _fertilizerRepositoryWrapper.ChemicalElementRepository.GetById(x.Id).Result,
                PercentageContent = x.PercentageContent
            }).ToList();

            var fertilizer = await _fertilizerRepositoryWrapper.FertilizerRepository.GetIncludedFertilizer(model.Id);
            fertilizer.Name = model.Name;
            fertilizer.FertilizerComponents = components;

            await _fertilizerRepositoryWrapper.FertilizerRepository.Update(fertilizer);
            TempData["Message"] = "Zmieniono nawóz: " + fertilizer.Name;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            var fertilizer = await _fertilizerRepositoryWrapper.FertilizerRepository.GetById(id);
            await _fertilizerRepositoryWrapper.FertilizerRepository.Delete(fertilizer);
            TempData["Message"] = fertilizer.Name + " został usunięty";
            return;
        }

        private void AddChemicalElementList()
        {
            ViewBag.ChemicalElementList = _fertilizerRepositoryWrapper.ChemicalElementRepository.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Symbol,
                Value = x.Id.ToString()
            });
        }
    }
}
