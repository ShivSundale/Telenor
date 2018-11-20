using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telenor.Infrastructure.EntityConfigurations
{
    public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<DbEntities.ProductCategory>
    {
        public void Configure(EntityTypeBuilder<DbEntities.ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalog_productcategory_hilo")
               .IsRequired();
            builder.Property(cb => cb.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
