using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class ChemicalElementConfiguration : IEntityTypeConfiguration<ChemicalElement>
    {
        public void Configure(EntityTypeBuilder<ChemicalElement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Symbol);
        }
    }
}
