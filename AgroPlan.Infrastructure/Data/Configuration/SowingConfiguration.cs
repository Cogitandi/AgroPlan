using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class SowingConfiguration : IEntityTypeConfiguration<Sowing>
    {
        public void Configure(EntityTypeBuilder<Sowing> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DosePerHa);
        }
    }
}
