using Ecommerce.Core.Repositories;
using System.Threading.Tasks;

namespace Ecommerce.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task CommitAsnyc();
        void Commit();
    }
}
