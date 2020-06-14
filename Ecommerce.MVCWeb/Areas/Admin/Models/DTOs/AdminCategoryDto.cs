using System.ComponentModel.DataAnnotations;

namespace Ecommerce.MVCWeb.Areas.Admin.Models.DTOs
{
    public class AdminCategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
