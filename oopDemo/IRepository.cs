namespace oopDemo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        IEnumerable<TEntity> GetAll();
    }
}
