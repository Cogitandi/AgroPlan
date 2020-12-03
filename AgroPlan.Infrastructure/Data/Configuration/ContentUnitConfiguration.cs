using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class ContentUnitConfiguration : IEntityTypeConfiguration<ContentUnit>
    {
        public void Configure(EntityTypeBuilder<ContentUnit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.ShortName);
        }
    }
}
