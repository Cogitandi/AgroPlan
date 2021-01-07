using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Core.RepositoryWrappers;
using AgroPlan.Web.Models.SprayingMixture;
using AgroPlan.Web.Models.Treatment;
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
    public class TreatmentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISprayingRepositoryWrapper _sprayingRepositoryWrapper;
        private readonly IFertilizerRepositoryWrapper _fertilizerRepositoryWrapper;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly ITreatmentKindRepository _treatmentKindRepository;
        private readonly IParcelCoveredByTreatmentRepository _parcelCoveredByTreatmentRepository;
        private readonly IFieldRepository _fieldRepository;
        private readonly IParcelRepository _parcelRepository;

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var treatments = await _treatmentRepository.FindByCondition(TreatmentsInclude,x => true);
            var parcels = await _parcelCoveredByTreatmentRepository.FindByCondition(ParcelCoveredByTreatmentInclude, x => true);
            var model = treatments.Select(x => {
                var area = 0; 
                foreach(var item in parcels.Where(y => y.Treatment.Id == x.Id))
                {
                    area += item.Parcel.CultivatedArea;
                }
                return new TreatmentViewModel()
                {
                    TreatmentId = x.Id,
                    Date = x.Date.ToString(),
                    TreatmentKind = x.TreatmentKind.Name,
                    FieldName = parcels.FirstOrDefault(y => y.Treatment == x).Parcel.Field.Name,
                    Area = (area/100.0).ToString(),
                };
            }
            );

            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var sprayingMixtureList = await _sprayingRepositoryWrapper.SprayingMixtureRepository.FindByCondition(x => x.Id==id);
            var sprayingMixture = sprayingMixtureList.FirstOrDefault();

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
        public async Task<ActionResult> GetParcels(Guid fieldId)
        {
            var fields = await _fieldRepository.FindByCondition(FiledsInclude, x => x.Id == fieldId);
            var field = fields.FirstOrDefault();
            var model = new TreatmentDetailViewModel();
            var parcels = field.Parcels.Select(x => new ParcelForTreatmentViewModel()
            {
                Id = x.Id,
                Number = x.Number,
                Area = x.CultivatedArea.ToString(),
            });
            model.Parcels = parcels;

            return PartialView("Parcels", model);
        }
        public async Task<ActionResult> Create()
        {
            await AddDataToForm();
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TreatmentDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Błąd: niepoprawne dane";
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.GetUserAsync(User);

            var parcels = new List<ParcelCoveredByTreatment>();
            foreach(var parcel in model.Parcels)
            {
                var item = new ParcelCoveredByTreatment()
                {
                    Parcel = await _parcelRepository.GetById(parcel.Id),
                };
                parcels.Add(item);
            }

            var treatmentKind = await _treatmentKindRepository.FindByCondition(x => x.Id == model.TreatmentKindId);
            var mixture = await _sprayingRepositoryWrapper.SprayingMixtureRepository.GetById(model.SprayingId);
            var treatment = new Treatment()
            {
                Date = model.Date,
                Notes = model.Notes,
                ParcelCoveredByTreatments = parcels,
                TreatmentKind = treatmentKind.FirstOrDefault(),
                Spraying = mixture,
            };
            await _treatmentRepository.Add(treatment);

            TempData["Message"] = "Dodano nowy zabieg";
            return RedirectToAction(nameof(Index));
        }
        
        private Func<DbSet<ParcelCoveredByTreatment>, IQueryable<ParcelCoveredByTreatment>> ParcelCoveredByTreatmentInclude =
                arg => arg
                .Include(x => x.Treatment)
                .Include(x => x.Parcel)
                    .ThenInclude(x => x.Field);

        private Func<DbSet<Field>, IQueryable<Field>> FiledsInclude =
                arg => arg
                .Include(x => x.Parcels);
        private Func<DbSet<Treatment>, IQueryable<Treatment>> TreatmentsInclude =
                arg => arg
                .Include(x => x.TreatmentKind);

        private async Task AddDataToForm()
        {
            var user = await _userManager.GetUserAsync(User);
            var treatmentKindList = _treatmentKindRepository.GetAll();
            var sprayingMixtureList = await _sprayingRepositoryWrapper.SprayingMixtureRepository.FindByCondition(x => x.User == user);
            var fertilizerList = _fertilizerRepositoryWrapper.FertilizerRepository.GetAll();
            var fieldList = await _fieldRepository.FindByCondition(FiledsInclude, x => x.User == user);
            ViewBag.FieldList = fieldList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            ViewBag.TreatmentKindList = treatmentKindList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            ViewBag.SprayingList = sprayingMixtureList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            ViewBag.FertilizerList = fertilizerList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
        }
        public TreatmentsController(UserManager<ApplicationUser> userManager, ISprayingRepositoryWrapper sprayingRepositoryWrapper, IFertilizerRepositoryWrapper fertilizerRepositoryWrapper, ITreatmentRepository treatmentRepository, ITreatmentKindRepository treatmentKindRepository, IParcelCoveredByTreatmentRepository parcelCoveredByTreatmentRepository, IFieldRepository fieldRepository, IParcelRepository parcelRepository)
        {
            _userManager = userManager;
            _sprayingRepositoryWrapper = sprayingRepositoryWrapper;
            _fertilizerRepositoryWrapper = fertilizerRepositoryWrapper;
            _treatmentRepository = treatmentRepository;
            _treatmentKindRepository = treatmentKindRepository;
            _parcelCoveredByTreatmentRepository = parcelCoveredByTreatmentRepository;
            _fieldRepository = fieldRepository;
            _parcelRepository = parcelRepository;
        }
    }
}
