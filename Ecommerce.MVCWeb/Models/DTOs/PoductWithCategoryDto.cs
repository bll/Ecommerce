namespace Ecommerce.MVCWeb.Models.DTOs
{
    public class PoductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
