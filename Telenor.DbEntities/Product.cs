using System;
using System.Collections.Generic;

namespace Telenor.DbEntities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public int CategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int BrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public IEnumerable<ProductFeature> ProductFeatures { get; set; }
    }
}
