using CustomerServices.Context;
using CustomerServices.Handlers.CommandHandlers;
using CustomerServices.RequestModels.CommandRequestModels;
using Xunit;

namespace CustomerServicesUnitTest
{
    public class CustomerCommandHandlerUnitTest
    {
        CustomerServicesDbContext context = null;
        CustomerCommandHandler customerCommandHandler = null;

        public CustomerCommandHandlerUnitTest()
        {
            if (this.context == null)
            {
                this.context = new CustomerServicesDbContext(); ;
                this.customerCommandHandler = new CustomerCommandHandler(context);
            }
        }

        [Fact]
        public void AddCustomer()
        {

            var customer = customerCommandHandler.Save(new CustomerRequestModel()
            {
                Name = "Test",
                Address = "Test",
                CityId = 2,
                CountryId = 1,
                PhoneNumber = "0000"
            });

            Assert.NotNull(customer);

        }
    }
}
