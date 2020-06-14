using Ecommerce.Core.Models;
using Ecommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private AppDbContext appDbContext { get => _dbContext as AppDbContext; }

        public ProductRepository(AppDbContext context) : base(context) {

        }
        public async Task<Product> GetWithCategoryByIdAsnyc(int productId) {

            return await appDbContext.Products.Include(x => x.Category).SingleAsync(x => x.Id == productId);
        }
        public async Task<List<Product>> GetProductsWithRelationsAsync() {

            return await appDbContext.Products.
                Include(x => x.ProductImages).
                Include(x => x.Category).ToListAsync();
        }
        public async Task<Product> GetProductWithImagesByIdAsync(int productId) {

            return await appDbContext.Products.
                Include(x => x.ProductImages).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
