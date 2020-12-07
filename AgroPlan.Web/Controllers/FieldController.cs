using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Web.Models.Field;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgroPlan.Web.Controllers
{
    [Authorize]
    [Route("pola/[action]")]
    public class FieldController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFieldRepository _fieldRepository;

        public FieldController(
            UserManager<ApplicationUser> userManager,
            IFieldRepository fieldRepository)
        {
            _userManager = userManager;
            _fieldRepository = fieldRepository;
        }

        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var list = await _fieldRepository.FindByCondition(include, x => x.User == user);

            var model = list.Select(x => new FieldListViewModel()
            {
                Id = x.Id,
                Number = x.Number,
                Name = x.Name,
                Area = Field.GetTotalArea(x.Parcels)

            });
            return View(model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFieldViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.GetUserAsync(User);
            var list = await _fieldRepository.FindByCondition(include, x => x.User == user);

            var parcels = model.Parcels.Select(x => new Parcel()
            {
                Number = x.Number,
                CultivatedArea = x.Area
            }).ToList();

            var field = new Field()
            {
                User = user,
                Number = Field.GetNumberForNewField(list),
                Name = model.Name,
                Parcels = parcels
            };

            await _fieldRepository.Add(field);
            TempData["Message"] = "Dodano nowe pole: " + field.Name;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddParcel(ParcelsPartialViewModel model)
        {
            model.Parcels = model.Parcels.Append(new ParcelViewModel());
            return PartialView("_Parcels", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteParcel(ParcelsPartialViewModel model, int index)
        {
            var toDelete = model.Parcels.ElementAt(index);
            model.Parcels = model.Parcels.Where(x => x != toDelete);
            ModelState.Clear();
            return PartialView("_Parcels", model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var fields = await _fieldRepository.FindByCondition(include, x => x.Id == id);
            var field = fields.FirstOrDefault();

            var model = new EditFieldViewModel()
            {
                Id = field.Id,
                Name = field.Name,
                Parcels = field.Parcels.Select(x => new ParcelViewModel()
                {
                    Id = x.Id,
                    Number = x.Number,
                    Area = x.CultivatedArea,
                })
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditFieldViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var fields = await _fieldRepository.FindByCondition(include, x => x.Id == model.Id);
            var field = fields.FirstOrDefault();

            var user = await _userManager.GetUserAsync(User);
            var parcels = model.Parcels.Select(x => new Parcel()
            {
                //Id = model.Id,
                Number = x.Number,
                CultivatedArea = x.Area
            }).ToList();


            field.Name = model.Name;
            field.Parcels = parcels;
            await _fieldRepository.Update(field);
            TempData["Message"] = "Zaaktualizowano pole: " + field.Name;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            var fields = await _fieldRepository.FindByCondition(x => x.Id == id);
            var field = fields.FirstOrDefault();
            await _fieldRepository.Delete(field);
            TempData["Message"] = "Pole " + field.Name + " zostało usunięte";
            return;
        }
        private Func<DbSet<Field>, IQueryable<Field>> include =
                arg => arg.Include(x => x.User).Include(x => x.Parcels);
    }
}
