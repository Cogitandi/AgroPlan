using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date);
            builder.Property(x => x.Notes);
            builder.HasOne(x => x.TreatmentKind);
            builder.HasOne(x => x.Spraying);
            builder.HasOne(x => x.Fertilization);
            builder.HasOne(x => x.Sowing);
        }
    }
}
