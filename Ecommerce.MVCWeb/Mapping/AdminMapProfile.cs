using Ecommerce.Core.Models;
using Ecommerce.MVCWeb.Areas.Admin.Models.DTOs;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.MVCWeb.Mapping
{
    public class AdminMapProfile : CommonMapProfile
    {
        public AdminMapProfile() {

            CreateMap<Category, AdminCategoryDto>();
            CreateMap<AdminCategoryDto, Category>();

            CreateMap<IFormFile, ProductImage>();

            CreateMap<ProductImage, Areas.Admin.Models.DTOs.AdminProductImageDto>();
            CreateMap<Areas.Admin.Models.DTOs.AdminProductImageDto, ProductImage>();

            CreateMap<Product, AdminProductDto>();
            CreateMap<AdminProductDto, Product>();
        }
    }
}
