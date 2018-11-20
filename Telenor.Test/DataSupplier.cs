using System;
using System.Collections.Generic;
using System.Text;
using Telenor.DbEntities;

namespace Telenor.Test
{
    internal static class DataSupplier
    {
        internal static string UT_Default_ProductBrandName = "UT_ProductBrand";
        internal static string UT_Default_ProductCategoryName = "UT_ProductCategoty";
        internal static string UT_Default_ProductFeatureTypeName = "UT_ProductFeatureType";

        internal static string UT_Default_Product_1_Name = "UT_Product_1_Name";
        internal static string UT_Default_Product_1_Description = "UT_Product_1_Description";
        internal static decimal UT_Default_Product_1_Price = 100;
        internal static string UT_Default_Product_1_PictureFileName = "UT_Product_1_PictureFileName";

        internal static string UT_Default_Product_2_Name = "UT_Product_2_Name";
        internal static string UT_Default_Product_2_Description = "UT_Product_2_Description";
        internal static decimal UT_Default_Product_2_Price = 200;
        internal static string UT_Default_Product_2_PictureFileName = "UT_Product_2_PictureFileName";

        internal static string UT_Default_ProductFeatureValue= "UT_Default_ProductFeatureValue";

        internal static ProductBrand SetupMockProductBrand()
        {
            return new ProductBrand { BrandName = UT_Default_ProductBrandName };
        }

        internal static ProductCategory SetupMockProductCategory(int parentCategoryId)
        {
            return new ProductCategory { CategoryName = UT_Default_ProductCategoryName, ParentCategoryId = parentCategoryId };
        }

        internal static ProductFeatureType SetupMockProductFeatureType()
        {
            return new ProductFeatureType { FeatureName = UT_Default_ProductFeatureTypeName };
        }

        internal static Product SetupMockProduct(int productCategoryId, int productBrandId)
        {
            return new Product
            {
                CategoryId = productCategoryId,
                BrandId = productBrandId,
                Description = UT_Default_Product_1_Description,
                Name = UT_Default_Product_1_Name,
                Price = UT_Default_Product_1_Price,
                PictureFileName = UT_Default_Product_1_PictureFileName
            };
        }

        internal static IEnumerable<Product> SetupMockProducts(int productCategoryId, int productBrandId)
        {
            return new Product []
            {
                new Product
                    {
                    CategoryId = productCategoryId,
                    BrandId = productBrandId,
                    Description = UT_Default_Product_1_Description,
                    Name = UT_Default_Product_1_Name,
                    Price = UT_Default_Product_1_Price,
                    PictureFileName = UT_Default_Product_1_PictureFileName
                },

                new Product
                {
                    CategoryId = productCategoryId,
                    BrandId = productBrandId,
                    Description = UT_Default_Product_2_Description,
                    Name = UT_Default_Product_2_Name,
                    Price = UT_Default_Product_2_Price,
                    PictureFileName = UT_Default_Product_2_PictureFileName
                },
            };
        }

        internal static ProductFeature SetupMockProductFeature(int productId, int productFeatureTypeId)
        {
            return new ProductFeature
            {
                FeatureId = productFeatureTypeId,
                FeatureValue = UT_Default_ProductFeatureValue,
                ProductId = productId
            };
        }

        internal static IEnumerable<ViewModel.ProductViewModel> SetupMockProductViewModels()
        {
            var productViewModels = new List<ViewModel.ProductViewModel>
            {
                new ViewModel.ProductViewModel
                {
                    
                },
                new ViewModel.ProductViewModel
                {
                    
                }
            };
            return productViewModels;
        }

        internal static ViewModel.ProductViewModel SetupMockProductViewModel()
        {
            return new ViewModel.ProductViewModel
            {
                
            };
        }
    }
}
