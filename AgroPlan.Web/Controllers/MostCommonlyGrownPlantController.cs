using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Repositories;
using AgroPlan.Web.Models.MostCommonlyGrownPlant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("MostPlants/[action]")]
    public class MostCommonlyGrownPlantController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMostCommonlyGrownPlantRepository _mostCommonlyGrownPlantRepository;
        private readonly IPlantRepository _plantRepository;

        public MostCommonlyGrownPlantController(
            UserManager<ApplicationUser> userManager,
            IMostCommonlyGrownPlantRepository mostCommonlyGrownPlantRepository,
            IPlantRepository plantRepository)
        {
            _userManager = userManager;
            _mostCommonlyGrownPlantRepository = mostCommonlyGrownPlantRepository;
            _plantRepository = plantRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var plants = _plantRepository.GetAll();
            var selectedPlantsByUser = await _mostCommonlyGrownPlantRepository.GetAllIncluded(user);

            var availablePlants = _plantRepository.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var model = new MostCommonlyGrownPlantViewModel()
            {
                AvailablePlants = availablePlants,
                SelectedPlants = selectedPlantsByUser.Select(x => x.Plant.Id.ToString())
            };
            return View(model);
        }

        [HttpPost]
        public async Task AssignPlant(Guid id)
        {
            var plant = await _plantRepository.GetById(id);
            if (plant != null)
            {
                var user = await _userManager.GetUserAsync(User);
                var mostCommonlyGrownPlants = await _mostCommonlyGrownPlantRepository.GetAllIncluded(user);
                var isUserhaveSelectedPlant = mostCommonlyGrownPlants.Where(x => x.Plant == plant).Count() != 0 ;

                if(isUserhaveSelectedPlant)
                {
                    return;
                }
                var mostCommonlyGrownPlant = new MostCommonlyGrownPlant()
                {
                    Plant = plant,
                    User = user,
                };
                await _mostCommonlyGrownPlantRepository.Add(mostCommonlyGrownPlant);
            }
        }
        [HttpPost]
        public async Task UnAssignPlant(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var selectedPlant = await _plantRepository.GetById(id);
            var mostCommonlyGrownPlants = await _mostCommonlyGrownPlantRepository.GetAllIncluded(user);
            var userPlants = mostCommonlyGrownPlants.Where(x => x.Plant == selectedPlant);

            for(int i=0;i< userPlants.Count();i++)
            {
                await _mostCommonlyGrownPlantRepository.Delete(userPlants.ElementAt(i));
            }
        }

    }
}
