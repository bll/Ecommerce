using Ecommerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public CategorySeed() {
        }
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.HasData(
                new Category { Id = 1, Name = "Bilgisayar" },
                new Category { Id = 2, Name = "Tablet" },
                new Category { Id = 3, Name = "Telefon" },
                new Category { Id = 4, Name = "Monitör" }
                );
        }
    }
}
