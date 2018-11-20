export class Product 
{
    Id: number;
    Name: string;
    Description: string;
    Price: number;
    PictureFileName: string;
    PictureUri: string;
    ProductFeatures:ProductFeatures [];
    ProductBrand: ProductBrand;
    ProductCategory: ProductCategory;
}
export class ProductBrand
{
    BrandName:string;
}
export class ProductCategory
{
    CategoryName:string;
}

export class ProductFeatures
{
    FeatureValue: string;
    ProductFeatureType: ProductFeatureType;
}
export class ProductFeatureType
{
    FeatureName:string;
}
