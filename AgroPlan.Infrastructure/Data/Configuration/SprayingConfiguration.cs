using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class SprayingConfiguration : IEntityTypeConfiguration<SprayingMixture>
    {
        public void Configure(EntityTypeBuilder<SprayingMixture> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.ReasonForUse);
            builder.HasMany(x => x.SprayingComponents);
            builder.HasOne(x => x.User);
        }
    }
}
