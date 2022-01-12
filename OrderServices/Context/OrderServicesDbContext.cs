using Microsoft.EntityFrameworkCore;
using OrderServices.Models;

namespace OrderServices.Context
{
    public class OrderServicesDbContext : DbContext
    {
        public OrderServicesDbContext()
        {
        }

        public OrderServicesDbContext(DbContextOptions<OrderServicesDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB;initial catalog=XyzShopOrderDB;persist security info=True;user id=sa;password=000;");

        public DbSet<Order> Order { get; set; }
    }
}
