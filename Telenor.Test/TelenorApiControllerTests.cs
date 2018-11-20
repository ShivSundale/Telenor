using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Telenor.Business.Interfaces;
using Telenor.ViewModel;
using Telenor.WebApi.Controllers;
using Xunit;

namespace Telenor.Test
{
    public class TelenorApiControllerTests
    {
        public TelenorApiControllerTests()
        {
            
        }

        [Fact]
        public async Task ProductController_Products_ReturnsOk_WithListOfProductViewModels()
        {
            var mockProductBl = new Mock<IProductBl>();
            var mockHostingEnv = new Mock<IHostingEnvironment>();
            mockProductBl.Setup(bl => bl.GetAllProducts())
                .ReturnsAsync(DataSupplier.SetupMockProductViewModels());
            var controller = new ProductController(mockProductBl.Object, mockHostingEnv.Object);
            
            var result = await controller.Products();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var viewModels = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(viewResult.Value);
            
            Assert.Equal(2, viewModels.Count());
        }

        [Fact]
        public async Task ProductController_GetProductById_ReturnsOk_WithSingleProductViewModels()
        {
            var mockProductBl = new Mock<IProductBl>();
            var mockHostingEnv = new Mock<IHostingEnvironment>();
            mockProductBl.Setup(bl => bl.GetProductById(1))
                .ReturnsAsync(DataSupplier.SetupMockProductViewModel());
            var controller = new ProductController(mockProductBl.Object, mockHostingEnv.Object);

            var result = await controller.GetProductById(1);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var viewModel = Assert.IsAssignableFrom<ProductViewModel>(viewResult.Value);

            Assert.NotNull(viewModel);
        }
    }
}
