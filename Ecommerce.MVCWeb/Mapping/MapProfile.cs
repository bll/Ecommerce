using Ecommerce.Core.Models;
using Ecommerce.MVCWeb.Models.DTOs;

namespace Ecommerce.MVCWeb.Mapping
{
    public class MapProfile : CommonMapProfile
    {
        public MapProfile() {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, PoductWithCategoryDto>();
            CreateMap<PoductWithCategoryDto, Product>();

            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageDto, ProductImage>();

            CreateMap<Product, PoductWithCategoryDto>();
            CreateMap<PoductWithCategoryDto, Product>();

        }
    }
}
