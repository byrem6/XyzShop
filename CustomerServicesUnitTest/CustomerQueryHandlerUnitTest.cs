using CustomerServices.Context;
using CustomerServices.Handlers.QueryHandlers;
using Xunit;


namespace CustomerServicesUnitTest
{
    public class CustomerQueryHandlerUnitTest
    {
        CustomerServicesDbContext context = null;
        CustomerQueryHandler customerQueryHandler = null;

        public CustomerQueryHandlerUnitTest()
        {
            if (this.context == null)
            {
                this.context = new CustomerServicesDbContext(); ;
                this.customerQueryHandler = new CustomerQueryHandler(context);
            }
        }

        [Fact]
        public void CustomerList()
        {
            var list = customerQueryHandler.GetCustomers();
            Assert.NotNull(list);
        }
    }
}
