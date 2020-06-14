using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ecommerce.Core.Models
{
    public class Product : ISoftDelete
    {
        public Product() {
            ProductImages = new Collection<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
        public virtual Category Category { get; set; }
    }
}
