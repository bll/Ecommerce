using Ecommerce.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsnyc(int productId);
        Task<List<Product>> GetProductsWithRelationsAsync();
        Task<Product> GetProductWithImagesByIdAsync(int productId);
    }
}
