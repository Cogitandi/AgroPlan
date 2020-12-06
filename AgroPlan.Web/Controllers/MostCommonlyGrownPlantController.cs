using AgroPlan.Core.Domain;
using AgroPlan.Infrastructure.Repositories;
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
    [Route("MostPlants/[action]")]
    public class MostCommonlyGrownPlantController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MostCommonlyGrownPlantRepository _mostCommonlyGrownPlantRepository;

        public MostCommonlyGrownPlantController(UserManager<ApplicationUser> userManager, MostCommonlyGrownPlantRepository mostCommonlyGrownPlantRepository)
        {
            _userManager = userManager;
            _mostCommonlyGrownPlantRepository = mostCommonlyGrownPlantRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var plantList = _mostCommonlyGrownPlantRepository
                .GetAll()
                .Where(x => x.User == user);

            return View(plantList);
        }
    }
}
