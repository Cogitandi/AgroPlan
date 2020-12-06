using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Repositories;
using AgroPlan.Web.Models;
using AgroPlan.Web.Models.Plant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("Plants/[action]")]
    public class PlantController : Controller
    {
        private readonly IPlantRepository _plantRepository;

        public PlantController(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public IActionResult Index()
        {
            var plantList = _plantRepository.GetAll();

            var model = plantList.Select(x => new PlantListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                EfaNitrogenRate = x.EfaNitrogenRate
            });
            return View(model);
        }
        public IActionResult Create(Guid id)
        {
            return PartialView(new CreatePlantViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlantViewModel model)
        {
            if(!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }
            var plant = new Plant()
            {
                Name = model.Name,
                EfaNitrogenRate = model.EfaNitrogenRate,
            };
            await _plantRepository.Add(plant);
            TempData["Message"] = "Dodano nową roślinę: "+plant.Name;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            var plant = await _plantRepository.GetById(id);
            await _plantRepository.Delete(plant);
            TempData["Message"] = plant.Name + " został usunięty";
            return;
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var plant = await _plantRepository.GetById(id);
            var model = new EditPlantViewModel()
            {
                Id = plant.Id,
                Name = plant.Name,
                EfaNitrogenRate = plant.EfaNitrogenRate,
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPlantViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }
            var plant = new Plant()
            {
                Id = model.Id,
                Name = model.Name,
                EfaNitrogenRate = model.EfaNitrogenRate,
            };
            await _plantRepository.Update(plant);
            TempData["Message"] = "Zmiany w " + plant.Name + " zostały zapisane";
            return RedirectToAction(nameof(Index));
        }

    }
}
