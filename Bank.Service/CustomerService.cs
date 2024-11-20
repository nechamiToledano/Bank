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
    public class CustomerService : IService<Customer>
    {
        readonly IRepository<Customer> _CustomerRepository;
        public CustomerService(IRepository<Customer> CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        public IEnumerable<Customer> GetAllAsync()
        {

            return _CustomerRepository.GetAllAsync();
        }

        public Customer GetAsync(int id)
        {
            return _CustomerRepository.GetByIdAsync(id);
        }

        public bool AddAsync(Customer Customer)
        {
            return _CustomerRepository.AddAsync(Customer);
        }

        public bool UpdateAsync(Customer Customer)
        {
            return _CustomerRepository.UpdateAsync(Customer);
        }

        public bool DeleteAsync(int id)
        {
            return _CustomerRepository.DeleteAsync(id);
        }
    }
}
