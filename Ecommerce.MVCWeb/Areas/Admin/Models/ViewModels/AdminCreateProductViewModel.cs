using Ecommerce.MVCWeb.Areas.Admin.Models.DTOs;
using System.Collections.Generic;

namespace Ecommerce.MVCWeb.Areas.Admin.Models.ViewModels
{
    public class AdminCreateProductViewModel
    {
        public IEnumerable<AdminCategoryDto> Categories { get; set; }
        public AdminProductDto Product { get; set; }

    }
}
