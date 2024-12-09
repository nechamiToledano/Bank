using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using Bank.Core.InterfaceRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service
{
    public class CustomerService : ICustomerService
    {
        readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddAsync(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteAsync(id);
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetByIdAsync(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllAsync();
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateAsync(customer);
        }
    }
}
