using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class SprayingComponentConfiguration : IEntityTypeConfiguration<SprayingComponent>
    {
        public void Configure(EntityTypeBuilder<SprayingComponent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content);
            builder.HasOne(x => x.Spraying);
            builder.HasOne(x => x.ContentUnit);
            builder.HasOne(x => x.SprayingProduct);
        }
    }
}
