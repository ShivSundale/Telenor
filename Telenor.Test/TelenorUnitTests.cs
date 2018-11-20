using System.Collections.Generic;
using AutoMapper;
using Moq;
using Telenor.Business;
using Telenor.Dal;
using Telenor.DbEntities;
using Telenor.ViewModel;
using Xunit;

namespace Telenor.Test
{
    public class TelenorUnitTests
    {
        private readonly Mock<IRepositoryProvider> _mockRepositoryProvider;
        private readonly Mock<IMapper> _mockMapper;

        public TelenorUnitTests()
        {
            _mockRepositoryProvider = new Mock<IRepositoryProvider>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void GetAllProductsTest()
        {
            _mockRepositoryProvider.Setup(x => x.ProductDal.GetAllProducts()).Returns(DataSupplier.SetupMockProducts(1,1));
            _mockMapper.Setup(x => x.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(It.IsAny<IEnumerable<Product>>())).Returns(DataSupplier.SetupMockProductViewModels());
            var productBl = new ProductBl(_mockRepositoryProvider.Object, _mockMapper.Object);
            var products = productBl.GetAllProducts();
            Assert.NotNull(productBl);
        }

        [Fact]
        public void GetProductByIdTest()
        {
            _mockRepositoryProvider.Setup(x => x.ProductDal.GetProductById(1)).Returns(DataSupplier.SetupMockProduct(1,1));
            _mockMapper.Setup(x => x.Map<Product, ProductViewModel>(It.IsAny<Product>())).Returns(DataSupplier.SetupMockProductViewModel());
            var productBl = new ProductBl(_mockRepositoryProvider.Object, _mockMapper.Object);
            var product = productBl.GetProductById(1);
            Assert.NotNull(product);
        }
    }
}
