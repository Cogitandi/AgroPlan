using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number);
            builder.Property(x => x.CultivatedArea);
            builder.HasOne(x => x.Field);
            builder.HasMany(x => x.Treatments);
        }
    }
}
