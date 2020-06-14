using Ecommerce.Core.Repositories;
using Ecommerce.Core.UnitOfWork;
using Ecommerce.Data.Repositories;
using System.Threading.Tasks;

namespace Ecommerce.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public UnitOfWork(AppDbContext appDbContext) {
            _context = appDbContext;
        }
        public void Commit() {
            _context.SaveChanges();
        }

        public async Task CommitAsnyc() {
            await _context.SaveChangesAsync();
        }
    }
}
