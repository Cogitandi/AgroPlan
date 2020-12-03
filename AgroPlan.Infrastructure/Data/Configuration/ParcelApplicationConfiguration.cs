using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class ParcelApplicationConfiguration : IEntityTypeConfiguration<ParcelApplication>
    {
        public void Configure(EntityTypeBuilder<ParcelApplication> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Parcel);
            builder.Property(x => x.Application);
        }
    }
}
