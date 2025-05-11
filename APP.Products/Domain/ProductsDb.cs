using Microsoft.EntityFrameworkCore;

namespace APP.Products.Domain
{
    public class ProductsDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductStore> ProductStores { get; set; }

        public ProductsDb(DbContextOptions options) : base(options)
        {
        }
    }
}
