using AgroPlan.Core.Domain;
using AgroPlan.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<ApplicationKind> ApplicationKinds { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<MostCommonlyGrownPlant> MostCommonlyGrownPlants { get; set; }
        public DbSet<ParcelApplication> ParcelApplications { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<YearPlan> YearPlans { get; set; }
        public DbSet<ParcelCoveredByTreatment> ParcelCoveredByTreatments { get; set; }
        public DbSet<TreatmentKind> TreatmentKinds { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Sowing> Sowings { get; set; }
        public DbSet<Spraying> Sprayings { get; set; }
        public DbSet<SprayingComponent> SprayingComponents { get; set; }
        public DbSet<SprayingProduct> SprayingProducts { get; set; }
        public DbSet<ContentUnit> ContentUnits { get; set; }
        public DbSet<Fertilization> Fertilizations { get; set; }
        public DbSet<Fertilizer> Fertilizers { get; set; }
        public DbSet<FertilizerComponent> FertilizerComponents { get; set; }
        public DbSet<ChemicalElement> ChemicalElements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationConfiguration());
            builder.ApplyConfiguration(new ApplicationKindConfiguration());
            builder.ApplyConfiguration(new ChemicalElementConfiguration());
            builder.ApplyConfiguration(new ContentUnitConfiguration());
            builder.ApplyConfiguration(new FertilizationConfiguration());
            builder.ApplyConfiguration(new FertilizerComponentConfiguration());
            builder.ApplyConfiguration(new FertilizerConfiguration());
            builder.ApplyConfiguration(new FieldConfiguration());
            builder.ApplyConfiguration(new MostCommonlyGrownPlantConfiguration());
            builder.ApplyConfiguration(new ParcelApplicationConfiguration());
            builder.ApplyConfiguration(new ParcelConfiguration());
            builder.ApplyConfiguration(new ParcelCoveredByTreatmentConfiguration());
            builder.ApplyConfiguration(new PlantConfiguration());
            builder.ApplyConfiguration(new SeasonConfiguration());
            builder.ApplyConfiguration(new SowingConfiguration());
            builder.ApplyConfiguration(new SprayingComponentConfiguration());
            builder.ApplyConfiguration(new SprayingConfiguration());
            builder.ApplyConfiguration(new SprayingProductConfiguration());
            builder.ApplyConfiguration(new TreatmentConfiguration());
            builder.ApplyConfiguration(new TreatmentKindConfiguration());
            builder.ApplyConfiguration(new YearPlanConfiguration());
        }

    }
}
