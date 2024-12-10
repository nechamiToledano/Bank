using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        bool DeleteCustomer(int id);
    }
}
