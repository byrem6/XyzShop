using CustomerServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerServices.Context
{
    public class CustomerServicesDbContext : DbContext
    {
        public CustomerServicesDbContext()
        {
        }

        public CustomerServicesDbContext(DbContextOptions<CustomerServicesDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB;initial catalog=XyzShopCustomerDB;persist security info=True;user id=sa;password=000;");
        public DbSet<Customer> Customer { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }

    }
}
