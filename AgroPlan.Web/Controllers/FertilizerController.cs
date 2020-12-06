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

        // GET: FertilizerController
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

        // GET: FertilizerController/Create
        public ActionResult Create()
        {
            AddChemicalElementList();
            return PartialView();
        }

        // POST: FertilizerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFertilizerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }
            var fertilizer = new Fertilizer()
            {
                Name = model.Name,
            };
            await _fertilizerRepositoryWrapper.FertilizerRepository.Add(fertilizer);
            TempData["Message"] = "Dodano nowy nawóz: "+ fertilizer.Name;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComponent(CreateFertilizerViewModel model)
        {
            model.Components = model.Components.Append(new FertilizerComponentViewModel());
            AddChemicalElementList();
            return PartialView("Create", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComponent(CreateFertilizerViewModel model,int index)
        {
            var toDelete = model.Components.ElementAt(index);
            model.Components = model.Components.Where(x => x != toDelete);
            AddChemicalElementList();
            ModelState.Clear();
            return PartialView("Create", model);
        }

        // GET: FertilizerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FertilizerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FertilizerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FertilizerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
