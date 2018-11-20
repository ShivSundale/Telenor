using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Telenor.Infrastructure
{
    public interface ICatalogContext
    {
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true,
            CancellationToken cancellationToken = default(CancellationToken));

        DbSet<DbEntities.Product> Products { get; set; }
        DbSet<DbEntities.ProductCategory> ProductCategories { get; set; }
        DbSet<DbEntities.ProductBrand> ProductBrands { get; set; }
        DbSet<DbEntities.ProductFeatureType> ProductFeatureTypes { get; set; }
        DbSet<DbEntities.ProductFeature> ProductFeatures { get; set; }
    }
}
