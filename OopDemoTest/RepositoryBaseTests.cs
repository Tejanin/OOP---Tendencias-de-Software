using oopDemo.Repository;
using oopDemo.UnitOfWork;

namespace OopDemoTest
{
    public class RepositoryBaseTests
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            _productRepository = new ProductRepository(unitOfWork);
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}