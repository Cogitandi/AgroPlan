using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.StartYear);
            builder.Property(x => x.EndYear);
            builder.HasOne(x => x.User);
            builder.HasMany(x => x.YearPlans)
                .WithOne(y=>y.Season)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Applications)
                .WithOne(y => y.Season)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
