using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class YearPlanConfiguration : IEntityTypeConfiguration<YearPlan>
    {
        public void Configure(EntityTypeBuilder<YearPlan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Field);
            builder.HasOne(x => x.Plant);
            builder.HasOne(x => x.Season);
        }
    }
}
