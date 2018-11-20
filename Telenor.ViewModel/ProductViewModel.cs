using System.Collections.Generic;

namespace Telenor.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }
        
        public ProductBrandViewModel ProductBrand { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }

        public IEnumerable<ProductFeatureViewModel> ProductFeatures { get; set; }
    }
}
