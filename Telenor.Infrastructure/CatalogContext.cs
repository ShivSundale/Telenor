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
            builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductFeatureTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductFeatureEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProductCategoryEntityTypeConfiguration());
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
