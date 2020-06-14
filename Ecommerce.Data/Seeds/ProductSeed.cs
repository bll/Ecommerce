using Ecommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public ProductSeed() {

        }
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.HasData(
                new Product { Id = 1, Name = "Bilgisayar", Price = 12.50m, Stock = 40, Barcode = "11XX", Image = "7a146db6-c8bb-41fe-9728-14bcdba30d15_format_webp2.jpg", Description = "Lorem ipsum", CategoryId = 1 },
                new Product { Id = 2, Name = "Mini Tablet", Price = 15m, Stock = 50, Barcode = "12XX", Image = "9cf2f066-8159-4cd1-9441-180e1968d7b5_format_webp.jpg", Description = "Lorem ipsum", CategoryId = 2 },
                new Product { Id = 3, Name = "Telefon", Price = 1m, Stock = 50, Barcode = "13XX", Image = "7a146db6-c8bb-41fe-9728-14bcdba30d15_format_webp2.jpg", Description = "Lorem ipsum", CategoryId = 3 },
                new Product { Id = 4, Name = "Monitör", Price = 25m, Stock = 500, Barcode = "14XX", Image = "7a146db6-c8bb-41fe-9728-14bcdba30d15_format_webp2.jpg", Description = "Lorem ipsum", CategoryId = 4 }
                );
        }
    }
}
