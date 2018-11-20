using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telenor.Infrastructure.EntityConfigurations;
using Telenor.Infrastructure.Helper;

namespace Telenor.Infrastructure
{
    public class CatalogContext : DbContext, ICatalogContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        public CatalogContext() { }

        public DbSet<DbEntities.Product> Products { get; set; }
        public DbSet<DbEntities.ProductCategory> ProductCategories { get; set; }
        public DbSet<DbEntities.ProductBrand> ProductBrands { get; set; }
        public DbSet<DbEntities.ProductFeatureType> ProductFeatureTypes { get; set; }
        public DbSet<DbEntities.ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<DbEntities.ProductCategory>().ToTable("ProductCategory")
            //    .HasKey(b => b.Id)
            //    .
            //    //.HasRequired(e => e.Person)
            //    //.(ci => ci.ProductCategory)
            //    //.WithMany()
            //    //.HasForeignKey(ci => ci.CategoryId)
            //builder.Entity<DbEntities.ProductBrand>().ToTable("ProductBrand")
            //    .HasKey(b => b.Id);
            //    //.HasMany(c => c.pro);
            //builder.Entity<DbEntities.ProductFeatureType>().ToTable("ProductFeatureType")
            //    .HasKey(b => b.Id);
            //builder.Entity<DbEntities.Product>().ToTable("Product")
            //    .HasKey(b => b.Id);
            //builder.Entity<DbEntities.ProductFeature>().ToTable("ProductFeature")
            //    .HasKey(b => b.Id);

            builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductFeatureTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductFeatureEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductCategoryEntityTypeConfiguration());
            //EnsureSeedData();
        }

        private void EnsureSeedData()
        {
            var productBrandsCount = default(int);
            var productCategoryCount = default(int);
            var productFeatureTypeCount = default(int);
            var productCount = default(int);
            var productFeatureCount = default(int);

            var dbSeeder = new DatabaseSeeder(this);

            if (!ProductBrands.Any())
            {
                productBrandsCount = dbSeeder.SeedProductBrandEntities().Result;
            }
            if (ProductCategories.Any())
            {
                productCategoryCount = dbSeeder.SeedProductCategoryEntities().Result;
            }
            if (ProductFeatureTypes.Any())
            {
                productFeatureTypeCount = dbSeeder.SeedProductFeatureTypeEntities().Result;
            }
            if (Products.Any())
            {
                productCount = dbSeeder.SeedProductEntities().Result;
            }
            if (ProductFeatures.Any())
            {
                productFeatureCount = dbSeeder.SeedProductFeatureEntities().Result;
            }

            //return productBrandsCount + productCategoryCount + productFeatureTypeCount + productCount + productFeatureCount;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
