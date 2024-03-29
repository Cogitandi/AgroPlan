using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Core.RepositoryWrappers;
using AgroPlan.Infrastructure.Data;
using AgroPlan.Infrastructure.Repositories;
using AgroPlan.Infrastructure.RepositoryWrappers;
using AgroPlan.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;

namespace AgroPlan.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<DatabaseContext>();
            //services.AddControllersWithViews();

            services.AddControllersWithViews(o =>
             {
                 o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((arg) => "Niepoprawna liczba");
                 o.ModelMetadataDetailsProviders.Add(new MetadataTranslationProvider(typeof(Resources)));
             });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddScoped<IMostCommonlyGrownPlantRepository, MostCommonlyGrownPlantRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IYearPlanRepository, YearPlanRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationKindRepository, ApplicationKindRepository>();
            services.AddScoped<IParcelApplicationRepository, ParcelApplicationRepository>();
            services.AddScoped<ITreatmentKindRepository, TreatmentKindRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<IParcelCoveredByTreatmentRepository, ParcelCoveredByTreatmentRepository>();
            services.AddScoped<IParcelRepository, ParcelRepository>();
            // wrappes
            services.AddScoped<IFertilizerRepositoryWrapper, FertilizerRepositoryWrapper>();
            services.AddScoped<ISprayingRepositoryWrapper, SprayingRepositoryWrapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
