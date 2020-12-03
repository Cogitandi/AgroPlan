using AgroPlan.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.Data.Configuration
{
    public class MostCommonlyGrownPlantConfiguration : IEntityTypeConfiguration<MostCommonlyGrownPlant>
    {
        public void Configure(EntityTypeBuilder<MostCommonlyGrownPlant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Plant);
        }
    }
}
