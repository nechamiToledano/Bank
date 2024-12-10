
using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bank.Api.Controllers
{
    [Route("Bank/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: /Bank/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = (List<Customer>)_customerService.GetAllCustomers();
            return customers == null ? NotFound() : customers;
        }

        // GET: /Bank/Customer/{id}
        [HttpGet("{id}")]

        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomer(id);
            return customer == null ? NotFound() : customer;
        }

        // POST: /Bank/Customer/NewCustomer
        [HttpPost]
        public ActionResult<Customer> AddCustomer([FromBody] Customer customer)
        {
            Customer newCustomer = _customerService.AddCustomer(customer);
            return newCustomer != null ? newCustomer : NotFound();
        }

        // PUT: /Bank/Customer/MyCustomer/{id}
        [HttpPut("{id}")]


        public ActionResult<Customer> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            Customer customer = _customerService.UpdateCustomer(id, updatedCustomer);
            return customer != null ? customer : NotFound();

        }
        [HttpDelete]
        public ActionResult<bool> DeleteCustomer(int id)
        {

            return _customerService.DeleteCustomer(id) ? true : NotFound();

        }
    }
}
