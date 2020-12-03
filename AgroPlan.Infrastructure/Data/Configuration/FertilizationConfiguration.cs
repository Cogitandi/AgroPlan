using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class FertilizationConfiguration : IEntityTypeConfiguration<Fertilization>
    {
        public void Configure(EntityTypeBuilder<Fertilization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DosePerHa);
            builder.HasOne(x => x.Fertilizer);
        }
    }
}
