using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telenor.Infrastructure.EntityConfigurations
{
    public class ProductBrandEntityTypeConfiguration : IEntityTypeConfiguration<DbEntities.ProductBrand>
    {
        public void Configure(EntityTypeBuilder<DbEntities.ProductBrand> builder)
        {
            builder.ToTable("ProductBrand");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).ForSqlServerUseSequenceHiLo("catalog_productbrand_hilo").IsRequired();
            builder.Property(cb => cb.BrandName).IsRequired().HasMaxLength(100);
        }
    }
}
