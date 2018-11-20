using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telenor.Infrastructure.Helper
{
    public class DatabaseSeeder
    {
        private readonly CatalogContext _context;

        public DatabaseSeeder(CatalogContext context)
        {
            _context = context;
        }

        public async Task<int> SeedProductBrandEntities()
        {
            var seedData = GetProductBrandsToSeed();
            _context.ProductBrands.AddRange(seedData);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SeedProductFeatureTypeEntities()
        {
            var seedData = GetProductFeatureTypesToSeed();
            _context.ProductFeatureTypes.AddRange(seedData);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SeedProductCategoryEntities()
        {
            var seedData = GetProductCategoryToSeed("Electronics");
            _context.ProductCategories.Add(seedData);
            var result = await _context.SaveChangesAsync();

            seedData = GetProductCategoryToSeed("Mobile", "Electronics");
            _context.ProductCategories.Add(seedData);
            result += await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> SeedProductEntities()
        {
            var seedData = GetProductsToSeed();
            _context.Products.AddRange(seedData);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SeedProductFeatureEntities()
        {
            _context.ProductFeatures.AddRange(GetAppleiPhone7ProductFeaturesToSeed());
            _context.ProductFeatures.AddRange(GetSamsungS8ProductFeaturesToSeed());
            _context.ProductFeatures.AddRange(GetOnePlus6ProductFeaturesToSeed());
            _context.ProductFeatures.AddRange(GethtcU12ProductFeaturesToSeed());
            return await _context.SaveChangesAsync();
        }

        private IEnumerable<DbEntities.ProductBrand> GetProductBrandsToSeed()
        {
            return new[]
            {
                 new DbEntities.ProductBrand{BrandName = "Apple"},
                 new DbEntities.ProductBrand{BrandName = "Samsung"},
                 new DbEntities.ProductBrand{BrandName = "OnePlus"},
                 new DbEntities.ProductBrand{BrandName = "htc"},
            };
        }

        private IEnumerable<DbEntities.ProductFeatureType> GetProductFeatureTypesToSeed()
        {
            return new[]
            {
                 new DbEntities.ProductFeatureType{FeatureName = "Operating System"},
                 new DbEntities.ProductFeatureType{FeatureName = "Storage"},
                 new DbEntities.ProductFeatureType{FeatureName = "RAM"},
                 new DbEntities.ProductFeatureType{FeatureName = "Screen Size"},
            };
        }

        private DbEntities.ProductCategory GetProductCategoryToSeed(string categoryName, string parentCategoryName = null)
        {
            var parentCategory = _context.ProductCategories.FirstOrDefault(x => x.CategoryName == parentCategoryName);
            return new DbEntities.ProductCategory { CategoryName = categoryName, ParentCategoryId = parentCategory?.Id };
        }

        private IEnumerable<DbEntities.Product> GetProductsToSeed()
        {
            var categoryIdLookup = _context.ProductCategories.ToDictionary(ct => ct.CategoryName, ct => ct.Id);
            var brandIdLookup = _context.ProductBrands.ToDictionary(ct => ct.BrandName, ct => ct.Id);

            return new[]
            {
                 new DbEntities.Product{CategoryId = categoryIdLookup["Mobile"],
                                        BrandId = brandIdLookup["Apple"],
                                        Description = "The Apple iPhone 7 is powered by 2.34GHz quad-core processor and it comes with 2GB of RAM. The phone packs 32GB of internal storage that cannot be expanded. As far as the cameras are concerned, the Apple iPhone 7 packs a 12-megapixel (f/1.8) primary camera on the rear and a 7-megapixel front shooter for selfies",
                                        Name = "iphone 7",
                                        Price = 100,
                                        PictureFileName ="iPhone7.jpg"},
                 new DbEntities.Product{CategoryId = categoryIdLookup["Mobile"],
                                        BrandId = brandIdLookup["Samsung"],
                                        Description = "Runs on Android 7.0 OS.The Phone comes with a large 3000 mAh battery to support it's 5.8 inch screen with Quad HD Plus Super AMOLED Capacitive touchscreen display having a resolution of 1440 x 2960 at 570 ppi. The screen is also protected by a Corning Gorilla Glass.",
                                        Name = "Samsung S8",
                                        Price = 100,
                                        PictureFileName ="SamsungS8.jpg"},
                 new DbEntities.Product{CategoryId = categoryIdLookup["Mobile"],
                                        BrandId = brandIdLookup["OnePlus"],
                                        Description = "The phone comes with a 6.28-inch touchscreen display with a resolution of 1080 pixels by 2280 pixels at a PPI of 402 pixels per inch. OnePlus 6 price in India starts from Rs. 34,999. The OnePlus 6 is powered by 2.8GHz octa-core (4x2.8GHz + 4x1.7GHz) processor and it comes with 8GB of RAM.",
                                        Name = "OnePlus 6",
                                        Price = 100,
                                        PictureFileName ="OnePlus-6.jpg"},
                 new DbEntities.Product{CategoryId = categoryIdLookup["Mobile"],
                                        BrandId = brandIdLookup["htc"],
                                        Description = "The HTC U12 Plus mobile features a 6.0 (15.24 cm) display with a screen resolution of 1440 x 2880 pixels and runs on Android v8.0 (Oreo) operating system.",
                                        Name = "htc U12 Plus",
                                        Price = 100,
                                        PictureFileName ="HTC-U12-Plus.jpg"}
            };
        }

        private IEnumerable<DbEntities.ProductFeature> GetAppleiPhone7ProductFeaturesToSeed()
        {
            var brandIdLookup = _context.ProductBrands.ToDictionary(ct => ct.BrandName, ct => ct.Id);
            var featureTypeIdLookup = _context.ProductFeatureTypes.ToDictionary(ct => ct.FeatureName, ct => ct.Id);
            var appleMobileProductLookup = _context.Products.Where(x=> x.BrandId == brandIdLookup["Apple"]).ToDictionary(ct => ct.Name, ct => ct.Id);
            var appleiPhone7ProductId = appleMobileProductLookup["iphone 7"];
            return new[]
            {
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Operating System"],
                                                FeatureValue ="ios 11", ProductId = appleiPhone7ProductId },
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Storage"],
                                                FeatureValue ="128 GB", ProductId = appleiPhone7ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["RAM"],
                                                FeatureValue ="3 GB", ProductId = appleiPhone7ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Screen Size"],
                                                FeatureValue ="5.0", ProductId = appleiPhone7ProductId},
            };
        }

        private IEnumerable<DbEntities.ProductFeature> GetSamsungS8ProductFeaturesToSeed()
        {
            var brandIdLookup = _context.ProductBrands.ToDictionary(ct => ct.BrandName, ct => ct.Id);
            var featureTypeIdLookup = _context.ProductFeatureTypes.ToDictionary(ct => ct.FeatureName, ct => ct.Id);
            var samsungMobileProductLookup = _context.Products.Where(x => x.BrandId == brandIdLookup["Samsung"]).ToDictionary(ct => ct.Name, ct => ct.Id);
            var samsungS8ProductId = samsungMobileProductLookup["Samsung S8"];

            return new[]
            {
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Operating System"],
                                                FeatureValue ="Android 7.0", ProductId = samsungS8ProductId },
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Storage"],
                                                FeatureValue ="64 GB", ProductId = samsungS8ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["RAM"],
                                                FeatureValue ="4 GB", ProductId = samsungS8ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Screen Size"],
                                                FeatureValue ="5.80", ProductId = samsungS8ProductId},
            };
        }

        private IEnumerable<DbEntities.ProductFeature> GetOnePlus6ProductFeaturesToSeed()
        {
            var brandIdLookup = _context.ProductBrands.ToDictionary(ct => ct.BrandName, ct => ct.Id);
            var featureTypeIdLookup = _context.ProductFeatureTypes.ToDictionary(ct => ct.FeatureName, ct => ct.Id);
            var onePlusMobileProductLookup = _context.Products.Where(x => x.BrandId == brandIdLookup["OnePlus"]).ToDictionary(ct => ct.Name, ct => ct.Id);
            var onePlus6ProductId = onePlusMobileProductLookup["OnePlus 6"];

            return new[]
            {
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Operating System"],
                                                FeatureValue ="Android 8.1 Oreo", ProductId = onePlus6ProductId },
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Storage"],
                                                FeatureValue ="128 GB", ProductId = onePlus6ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["RAM"],
                                                FeatureValue ="8 GB", ProductId = onePlus6ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Screen Size"],
                                                FeatureValue ="6.28", ProductId = onePlus6ProductId},
            };
        }

        private IEnumerable<DbEntities.ProductFeature> GethtcU12ProductFeaturesToSeed()
        {
            var brandIdLookup = _context.ProductBrands.ToDictionary(ct => ct.BrandName, ct => ct.Id);
            var featureTypeIdLookup = _context.ProductFeatureTypes.ToDictionary(ct => ct.FeatureName, ct => ct.Id);
            var onePlusMobileProductLookup = _context.Products.Where(x => x.BrandId == brandIdLookup["htc"]).ToDictionary(ct => ct.Name, ct => ct.Id);
            var onePlus6ProductId = onePlusMobileProductLookup["htc U12 Plus"];

            return new[]
            {
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Operating System"],
                                                FeatureValue ="Android 8.0 Oreo with HTC Sense", ProductId = onePlus6ProductId },
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Storage"],
                                                FeatureValue ="128 GB", ProductId = onePlus6ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["RAM"],
                                                FeatureValue ="6 GB", ProductId = onePlus6ProductId},
                 new DbEntities.ProductFeature{FeatureId = featureTypeIdLookup["Screen Size"],
                                                FeatureValue ="6.0", ProductId = onePlus6ProductId},
            };
        }
    }
}
