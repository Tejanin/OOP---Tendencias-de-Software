
namespace oopDemo
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly FoodContext _foodContext;

        public ProductRepository(FoodContext foodContext)
        {
            _foodContext = foodContext;
        }

        bool IRepository<Product>.Add(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                }

                _foodContext.Set<Product>().Add(entity);
                _foodContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }   
        }

        bool IRepository<Product>.Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return false;
                }

                _foodContext.Set<Product>().Remove(_foodContext.Set<Product>().FirstOrDefault(x => x.ID == id)!);
                _foodContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        Product IRepository<Product>.Get(int id)
        {
            return _foodContext.Set<Product>().FirstOrDefault(x => x.ID == id) ?? new Product();
        }

        IEnumerable<Product> IRepository<Product>.GetAll()
        {
            return _foodContext.Set<Product>().ToList();
        }

        bool IRepository<Product>.Update(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                }

                _foodContext.Set<Product>().Update(entity);
                _foodContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
