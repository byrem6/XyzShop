using CustomerServices.CommandRequestModels;
using CustomerServices.Context;
using CustomerServices.Contracts.CommandHandler;
using CustomerServices.Models;
using CustomerServices.RequestModels.CommandRequestModels;
using System;
using System.Threading.Tasks;

namespace CustomerServices.Handlers.CommandHandlers
{
    public class CustomerCommandHandler : ICustomerCommandHandler
    {
        private CustomerServicesDbContext _db;

        public CustomerCommandHandler(CustomerServicesDbContext db)
        {
            _db = db;
        }



        public async Task<Customer> Save(CustomerRequestModel requestModel)
        {

            var customer = new Customer()
            {
                Name = requestModel.Name,
                CityId = requestModel.CityId,
                CountryId = requestModel.CountryId,
                PhoneNumber = requestModel.PhoneNumber,
                Address = requestModel.Address,
                CreatedDate = DateTime.Now,
                IsRemoved = false,
                UpdatedDate = DateTime.Now

            };


            _db.Customer.Add(customer);
            await _db.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomer(CustomerUpdateRequestModel customerUpdateRequestModel)
        {
            var customer = _db.Customer.Find(customerUpdateRequestModel.Id);
            customer.Name = customerUpdateRequestModel.Customer.Name;
            customer.CityId = customerUpdateRequestModel.Customer.CityId;
            customer.CountryId = customerUpdateRequestModel.Customer.CountryId;
            customer.PhoneNumber = customerUpdateRequestModel.Customer.PhoneNumber;
            customer.Address = customerUpdateRequestModel.Customer.Address;
            customer.UpdatedDate = DateTime.Now;

            await _db.SaveChangesAsync();

            return customer;
        }
    }
}
