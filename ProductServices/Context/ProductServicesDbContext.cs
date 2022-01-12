using Microsoft.EntityFrameworkCore;
using ProductServices.Models;

namespace ProductServices.Context
{

    public class ProductServicesDbContext : DbContext
    {
        public ProductServicesDbContext()
        {
        }

        public ProductServicesDbContext(DbContextOptions<ProductServicesDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB;initial catalog=XyzShopProductDB;persist security info=True;user id=sa;password=000;");

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

    }
}
