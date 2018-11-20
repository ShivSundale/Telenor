using System;
using System.Linq;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Telenor.Dal;
using Telenor.Infrastructure;
using Xunit;

namespace Telenor.Test
{
    public class TelenorIntegrationTests : IDisposable
    {
        private readonly CatalogContext _context;
        private readonly ProductDal _productDal;

        public TelenorIntegrationTests()
        {
            var dbOptions = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _context = new CatalogContext(dbOptions);
            _productDal = new ProductDal(_context);
        }

        [Fact]
        public void GetProductByIdTest()
        {
            using (var scope = new TransactionScope())
            {
                var productCategory = DataSupplier.SetupMockProductCategory(0);
                _context.Add(productCategory);
                _context.SaveChanges();
                var addedProductCategory = _context.ProductCategories.FirstOrDefault(x => x.Id == productCategory.Id);
                Assert.NotNull(addedProductCategory);

                var productBrand = DataSupplier.SetupMockProductBrand();
                _context.Add(productBrand);
                _context.SaveChanges();
                var addedProductBrand = _context.ProductBrands.FirstOrDefault(x => x.Id == productBrand.Id);
                Assert.NotNull(addedProductBrand);

                var productFeatureType = DataSupplier.SetupMockProductFeatureType();
                _context.Add(productFeatureType);
                _context.SaveChanges();
                var addedProductFeatureType = _context.ProductFeatureTypes.FirstOrDefaultAsync(x => x.Id == productFeatureType.Id);
                Assert.NotNull(addedProductFeatureType);

                var product = DataSupplier.SetupMockProduct(addedProductCategory.Id, addedProductBrand.Id);
                _context.Add(product);
                _context.SaveChanges();

                var addedProduct = _productDal.GetProductById(product.Id);
                Assert.NotNull(addedProduct);

            }
        }

        [Fact]
        public void GetAllProductsTest()
        {
            using (var scope = new TransactionScope())
            {
                var productCategory = DataSupplier.SetupMockProductCategory(0);
                _context.Add(productCategory);
                _context.SaveChanges();
                var addedProductCategory = _context.ProductCategories.FirstOrDefault(x => x.Id == productCategory.Id);
                Assert.NotNull(addedProductCategory);

                var productBrand = DataSupplier.SetupMockProductBrand();
                _context.Add(productBrand);
                _context.SaveChanges();
                var addedProductBrand = _context.ProductBrands.FirstOrDefault(x => x.Id == productBrand.Id);
                Assert.NotNull(addedProductBrand);

                var productFeatureType = DataSupplier.SetupMockProductFeatureType();
                _context.Add(productFeatureType);
                _context.SaveChanges();
                var addedProductFeatureType = _context.ProductFeatureTypes.FirstOrDefaultAsync(x => x.Id == productFeatureType.Id);
                Assert.NotNull(addedProductFeatureType);

                var products = DataSupplier.SetupMockProducts(addedProductCategory.Id, addedProductBrand.Id);
                _context.AddRange(products);
                _context.SaveChanges();

                var addedProducts = _productDal.GetAllProducts();
                Assert.NotNull(addedProducts);
                Assert.Equal(2,addedProducts.Count());

            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
