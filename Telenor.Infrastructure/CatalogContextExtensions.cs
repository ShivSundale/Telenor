using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telenor.Infrastructure.Helper;

namespace Telenor.Infrastructure
{
    public static class CatalogContextExtensions
    {
        public static int EnsureSeedData(this CatalogContext context)
        {
            var productBrandsCount = default(int);
            var productCategoryCount = default(int);
            var productFeatureTypeCount = default(int);
            var productCount = default(int);
            var productFeatureCount = default(int);

            var dbSeeder = new DatabaseSeeder(context);
            if (!context.ProductBrands.Any())
            {
                productBrandsCount = dbSeeder.SeedProductBrandEntities().Result;
            }
            if (!context.ProductCategories.Any())
            {
                productCategoryCount = dbSeeder.SeedProductCategoryEntities().Result;
            }
            if (!context.ProductFeatureTypes.Any())
            {
                productFeatureTypeCount = dbSeeder.SeedProductFeatureTypeEntities().Result;
            }
            if (!context.Products.Any())
            {
                productCount = dbSeeder.SeedProductEntities().Result;
            }
            if (!context.ProductFeatures.Any())
            {
                productFeatureCount = dbSeeder.SeedProductFeatureEntities().Result;
            }

            return productBrandsCount + productCategoryCount + productFeatureTypeCount + productCount + productFeatureCount;
        }
    }
}
