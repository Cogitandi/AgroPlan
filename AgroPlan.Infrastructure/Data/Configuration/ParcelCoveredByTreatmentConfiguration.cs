using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class ParcelCoveredByTreatmentConfiguration : IEntityTypeConfiguration<ParcelCoveredByTreatment>
    {
        public void Configure(EntityTypeBuilder<ParcelCoveredByTreatment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Parcel);
            builder.HasOne(x => x.Treatment);
        }
    }
}
