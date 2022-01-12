using CustomerServices.CommandRequestModels;
using CustomerServices.Contracts.CommandHandler;
using CustomerServices.Contracts.QueryHandlers;
using CustomerServices.Models;
using CustomerServices.RequestModels.CommandRequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServices.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerCommandHandler _customerCommandHandler;
        private readonly ICustomerQueryHandler _customerQueryHandler;

        public CustomerController(ILogger<CustomerController> logger, ICustomerCommandHandler customerCommandHandler, ICustomerQueryHandler customerQueryHandler)
        {
            _logger = logger;
            _customerCommandHandler = customerCommandHandler;
            _customerQueryHandler = customerQueryHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerQueryHandler.GetCustomers();
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerQueryHandler.GetCustomer(id);
            return customer != null ? new JsonResult(customer) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomer(CustomerRequestModel customer)
        {
            _logger.LogDebug("Add New Customer", new JsonResult(customer));

            var newCustomer = await _customerCommandHandler.Save(customer);

            _logger.LogDebug("Success Add New Customer", new JsonResult(customer));

            return new JsonResult(newCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateRequestModel customerUpdateDTO)
        {
            _logger.LogDebug("Update Customer", new JsonResult(customerUpdateDTO.Customer));

            var updatedCustomer = await _customerCommandHandler.UpdateCustomer(customerUpdateDTO);

            _logger.LogDebug("Success Update Customer", new JsonResult(customerUpdateDTO.Customer));

            return new JsonResult(updatedCustomer);
        }
    }
}
