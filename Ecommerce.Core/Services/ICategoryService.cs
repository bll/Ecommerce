using Ecommerce.Core.Models;
using System.Threading.Tasks;

namespace Ecommerce.Core.Services
{
    public interface ICategoryService : IService<Category>
    {

        Task<Category> GetWithProductsByIdAsnyc(int categoryId);
    }
}
