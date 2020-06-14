using System.Collections.Generic;

namespace Ecommerce.MVCWeb.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public List<ProductImageDto> ProductImages { get; set; }
        public CategoryDto ProductCategory { get; set; }

    }
}
