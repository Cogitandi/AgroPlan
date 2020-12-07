using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Web.Models.Application;
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
    public class ApplicationController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IParcelApplicationRepository _parcelApplicationRepository;
        private readonly ISeasonRepository _seasonRepository;

        public ApplicationController(
        IApplicationRepository applicationRepository,
        IParcelApplicationRepository parcelApplicationRepository,
        ISeasonRepository seasonRepository)
        {
            _applicationRepository = applicationRepository;
            _parcelApplicationRepository = parcelApplicationRepository;
            _seasonRepository = seasonRepository;
        }

        public async Task<ActionResult> Index(Guid seasonId)
        {
            var seasons = await _seasonRepository.FindByCondition(x => x.Id == seasonId);
            var season = seasons.FirstOrDefault();
            var applicationList = await _applicationRepository
                .FindByCondition(dbSet=>dbSet.Include(x=>x.ApplicationKind),x => x.Season == season);

            var model = applicationList.Select(x => new ApplicationListViewModel()
            {
                Id = x.Id,
                Name = x.ApplicationKind.Name

            });
            return View(model);
        }
        public async Task<ActionResult> Detail(Guid applicationId)
        {
            var applicationList = await _applicationRepository.FindByCondition(x => x.Id == applicationId);
            var application = applicationList.FirstOrDefault();
            var parcelApplicationList = await _parcelApplicationRepository.FindByCondition(include, x => x.Application == application);

            var model = parcelApplicationList.Select(x => new ApplicationDetailViewModel()
            {
                Id = x.Id,
                FieldName = x.Parcel.Field.Name,
                Area = x.Parcel.CultivatedArea,
                Checked = x.IsApplicated,
                ParcelNumber = x.Parcel.Number
            });
            return View(model);
        }
        [HttpPost]
        public async Task ChangeApplicationStatus(Guid id)
        {
            var parcelApplications = await _parcelApplicationRepository.FindByCondition(x => x.Id == id);
            var parcelApplication = parcelApplications.FirstOrDefault();
            if (parcelApplication != null)
            {
                var previousStatus = parcelApplication.IsApplicated;
                parcelApplication.IsApplicated = previousStatus == true ? false : true;
                await _parcelApplicationRepository.Update(parcelApplication);
            }
        }
        private Func<DbSet<ParcelApplication>, IQueryable<ParcelApplication>> include =
                arg => arg.Include(x => x.Parcel)
                .ThenInclude(y => y.Field);


    };
}
