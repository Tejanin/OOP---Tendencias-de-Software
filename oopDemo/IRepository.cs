namespace oopDemo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        IEnumerable<TEntity> GetAll();

    }
}
