using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class FertilizerComponentConfiguration : IEntityTypeConfiguration<FertilizerComponent>
    {
        public void Configure(EntityTypeBuilder<FertilizerComponent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PercentageContent);
            builder.Property(x => x.ChemicalElement);
            builder.HasOne(x => x.Fertilizer);
        }
    }
}
