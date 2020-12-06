using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number);
            builder.Property(x => x.Name);
            builder.HasOne(x => x.User);
            builder.HasMany(x => x.Parcels);
            builder.HasMany(x => x.YearPlans);
        }
    }
}
