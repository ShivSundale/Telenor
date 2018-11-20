using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telenor.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<DbEntities.Product>
    {
        public void Configure(EntityTypeBuilder<DbEntities.Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(ci => ci.Id);
            builder.Property(pi => pi.Id)
                .ForSqlServerUseSequenceHiLo("catalog_product_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.PictureFileName)
                .IsRequired(false);

            builder.HasOne(ci => ci.ProductBrand)
                .WithMany()
                .HasForeignKey(ci => ci.BrandId);

            builder.HasOne(ci => ci.ProductCategory)
                .WithMany()
                .HasForeignKey(ci => ci.CategoryId);

            builder.HasMany(ci => ci.ProductFeatures)
                .WithOne(c => c.Product)
                .HasForeignKey(ci => ci.ProductId);
        }
    }
}
