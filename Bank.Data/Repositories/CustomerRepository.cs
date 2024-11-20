using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.InterfaceRepository;
using Bank.Core.InterfaceService;
using System.Security.Principal;

namespace Bank.Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {

            _dataContext = dataContext;

        }

        public IEnumerable<Customer> GetAllAsync()
        {
            List<Customer> customers = _dataContext.LoadData<Customer>();
            return _dataContext.LoadData<Customer>() == null ? null : customers.FindAll(c=> c.Status == CustomerStatus.Active);
        }
        public Customer GetByIdAsync(int id)
        {
            List<Customer> customers = _dataContext.LoadData<Customer>();


            return customers == null ? null : customers.Find(customer => customer.Id == id);

        }
        public bool AddAsync(Customer Customer)
        {
            List<Customer> customers = _dataContext.LoadData<Customer>();

            if (customers != null)
            {
                customers.Add(Customer);
                _dataContext.SaveData(customers);
                return true;
            }
            return false;
        }
        public bool UpdateAsync(Customer updatedCustomer)
        {
            List<Customer> customers = _dataContext.LoadData<Customer>();
            if (customers == null) { return false; }
            Customer customer = customers.Find(Customer => Customer.Id == updatedCustomer.Id);
            if (customer == null)
                return false;
            customer.Status = updatedCustomer.Status;
            customer.Address = updatedCustomer.Address;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;
            customer.AccountId = updatedCustomer.AccountId;


            _dataContext.SaveData(customers);

            return true;
        }
        public bool DeleteAsync(int id)
        {
            List<Customer> customers = _dataContext.LoadData<Customer>();
            if ( customers == null) { return false; }

            var customer = customers.Find(customer => customer.Id == id);
            if (customer == null)
                return false;
            customers.Remove(customer);
            _dataContext.SaveData(customers);
            return true;
        }
    }
}
