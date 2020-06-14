using Ecommerce.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsnyc(int productId);
        Task<List<Product>> GetProductsWithRelationsAsync();
        Task<Product> GetProductWithImagesByIdAsync(int productId);

    }
}
