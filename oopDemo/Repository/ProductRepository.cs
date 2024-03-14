using oopDemo.Models;
using oopDemo.UnitOfWork;

namespace oopDemo.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(IUnitOfWork unitOfwork) : base(unitOfwork)
        {
        }
    }
}
