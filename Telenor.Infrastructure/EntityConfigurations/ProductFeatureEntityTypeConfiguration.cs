using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telenor.Infrastructure.EntityConfigurations
{
    public class ProductFeatureEntityTypeConfiguration : IEntityTypeConfiguration<DbEntities.ProductFeature>
    {
        public void Configure(EntityTypeBuilder<DbEntities.ProductFeature> builder)
        {
            builder.ToTable("ProductFeature");
            builder.HasKey(ci => ci.Id);
            builder.Property(pi => pi.Id)
                .ForSqlServerUseSequenceHiLo("catalog_productfeature_hilo")
                .IsRequired();

            builder.Property(ci => ci.FeatureValue)
                .IsRequired(true)
                .HasMaxLength(500);

            builder.HasOne(ci => ci.ProductFeatureType)
                .WithMany()
                .HasForeignKey(ci => ci.FeatureId);
        }
    }
}
