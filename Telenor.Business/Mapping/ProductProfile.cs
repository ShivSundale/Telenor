using AutoMapper;

namespace Telenor.Business.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<DbEntities.Product, ViewModel.ProductViewModel>()
               .ForMember(dest => dest.ProductCategory, source => source.Ignore())
               .ForMember(dest => dest.ProductBrand, source => source.Ignore())
               .ForMember(dest => dest.ProductFeatures, source => source.Ignore());

            CreateMap<DbEntities.ProductCategory, ViewModel.ProductCategoryViewModel>();
            CreateMap<DbEntities.ProductBrand, ViewModel.ProductBrandViewModel>();
            CreateMap<DbEntities.ProductFeature, ViewModel.ProductFeatureViewModel>();
            CreateMap<DbEntities.ProductFeatureType, ViewModel.ProductFeatureTypeViewModel>();

            CreateMap<ViewModel.ProductCategoryViewModel, DbEntities.ProductCategory>();
            CreateMap<ViewModel.ProductBrandViewModel, DbEntities.ProductBrand>();
            CreateMap<ViewModel.ProductFeatureViewModel, DbEntities.ProductFeature>();
            CreateMap<ViewModel.ProductFeatureTypeViewModel, DbEntities.ProductFeatureType>();

            CreateMap<ViewModel.ProductViewModel, DbEntities.Product>()
            .ForMember(dest => dest.ProductCategory, source => source.MapFrom(src => src.ProductCategory))
            .ForMember(dest => dest.ProductBrand, source => source.MapFrom(src => src.ProductBrand))
            .ForMember(dest => dest.ProductFeatures, source => source.MapFrom(src => src.ProductFeatures));
        }
    }
}
