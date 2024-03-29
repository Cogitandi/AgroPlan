﻿using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Season);
            builder.HasOne(x => x.ApplicationKind);
            builder.HasMany(x => x.ParcelApplications);
        }
    }
}
