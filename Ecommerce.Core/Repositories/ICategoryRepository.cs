using Ecommerce.Core.Models;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsnyc(int categoryId);
    }
}
