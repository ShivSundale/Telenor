using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telenor.Infrastructure.EntityConfigurations
{
    public class ProductFeatureTypeEntityTypeConfiguration : IEntityTypeConfiguration<DbEntities.ProductFeatureType>
    {
        public void Configure(EntityTypeBuilder<DbEntities.ProductFeatureType> builder)
        {
            builder.ToTable("ProductFeatureType");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalog_productfeaturetype_hilo")
               .IsRequired();
            builder.Property(cb => cb.FeatureName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
