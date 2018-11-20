using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telenor.Business.Interfaces;
using Telenor.ViewModel;

namespace Telenor.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBl _productBl;
        private readonly IHostingEnvironment _hostingEnv;
        public ProductController(IProductBl productBl, IHostingEnvironment hostingEnv)
        {
            _productBl = productBl;
            _hostingEnv = hostingEnv;
        }
        // GET api/v1/[controller]/products
        [HttpGet]
        //[Route("products")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Products()
        {
            var products = await _productBl.GetAllProducts();
            return Ok(products);
        }

        //[HttpGet]
        //[Route("products/{id:int}")]
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await _productBl.GetProductById(id);

            if (product != null)
                return Ok(product);
            return NotFound();
        }
    }
}