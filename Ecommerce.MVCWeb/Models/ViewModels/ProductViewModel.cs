using Ecommerce.MVCWeb.Models.DTOs;
using System.Collections.Generic;

namespace Ecommerce.MVCWeb.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
