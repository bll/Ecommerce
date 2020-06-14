using Ecommerce.Core.Models;
using Ecommerce.Core.Repositories;
using Ecommerce.Core.Services;
using Ecommerce.Core.UnitOfWork;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork,
            repository) {
            _unitOfWork = unitOfWork;

        }

        public async Task<Category> GetWithProductsByIdAsnyc(int categoryId) {
            return await _unitOfWork.Categories.GetWithProductsByIdAsnyc(categoryId);
        }
    }
}
