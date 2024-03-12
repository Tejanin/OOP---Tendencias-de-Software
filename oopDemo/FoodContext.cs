using Microsoft.EntityFrameworkCore;

namespace oopDemo
{
    public class FoodContext: DbContext

    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
            
        }

        DbSet<Product> Products { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
