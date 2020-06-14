using Ecommerce.Core.Models;
using Ecommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private AppDbContext appDbContext { get => _dbContext as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context) {

        }

        public async Task<Category> GetWithProductsByIdAsnyc(int categoryId) {
            return await appDbContext.Categories.Include(x => x.Products).SingleAsync(x => x.Id == categoryId);
        }
    }
}
