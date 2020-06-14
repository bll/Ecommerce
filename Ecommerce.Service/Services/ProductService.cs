using Ecommerce.Core.Models;
using Ecommerce.Core.Repositories;
using Ecommerce.Core.Services;
using Ecommerce.Core.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork,
            repository) {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetWithCategoryByIdAsnyc(int productId) {
            return await _unitOfWork.Products.GetWithCategoryByIdAsnyc(productId);
        }

        public async Task<List<Product>> GetProductsWithRelationsAsync() {
            return await _unitOfWork.Products.GetProductsWithRelationsAsync();
        }

        public async Task<Product> GetProductWithImagesByIdAsync(int productId) {
            return await _unitOfWork.Products.GetProductWithImagesByIdAsync(productId);
        }
    }
}
