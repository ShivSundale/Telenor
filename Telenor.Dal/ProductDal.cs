using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Telenor.Dal.Interfaces;
using Telenor.DbEntities;
using Telenor.Infrastructure;

namespace Telenor.Dal
{
    public class ProductDal : IProductDal
    {
        private readonly CatalogContext _context;

        public ProductDal(CatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(x => x.ProductCategory)
                                    .Include(x => x.ProductBrand)
                                    .Include(x => x.ProductFeatures)
                                    .ThenInclude(x=> x.ProductFeatureType);
        }

        public Product GetProductById(int productId)

        {
            return _context.Products.Include(x => x.ProductCategory)
                                    .Include(x => x.ProductBrand)
                                    .Include(x => x.ProductFeatures)
                                    .ThenInclude(x => x.ProductFeatureType)
                                    .FirstOrDefault(p => p.Id == productId);
        }
    }
}
