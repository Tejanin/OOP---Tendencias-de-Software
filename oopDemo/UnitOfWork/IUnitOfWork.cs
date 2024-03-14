using Microsoft.EntityFrameworkCore;

namespace oopDemo.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
