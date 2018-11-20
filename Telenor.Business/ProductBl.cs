using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Telenor.Business.Interfaces;
using Telenor.Dal;
using Telenor.Dal.Interfaces;
using Telenor.DbEntities;
using Telenor.ViewModel;

namespace Telenor.Business
{
    public class ProductBl : IProductBl
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IMapper _mapper;
        
        public ProductBl(IRepositoryProvider repositoryProvider, IMapper mapper)
        {
            _repositoryProvider = repositoryProvider;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var productEntities = _repositoryProvider.ProductDal.GetAllProducts();
            var productViewModels = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productEntities);
            return productViewModels;
        }
        public async Task<ProductViewModel> GetProductById(int productId)
        {
            var product = _repositoryProvider.ProductDal.GetProductById(productId);
            var productViewModel = _mapper.Map<Product, ProductViewModel>(product);
            return productViewModel;
        }
    }
}
