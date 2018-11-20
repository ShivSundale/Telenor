namespace Telenor.DbEntities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureValue { get; set; }
        public Product Product { get; set; }
        public ProductFeatureType ProductFeatureType { get; set; }
    }
}

