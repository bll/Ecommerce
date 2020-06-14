namespace Ecommerce.Core.Models
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
