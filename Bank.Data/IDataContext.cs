using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data
{
    public interface IDataContext
    {


        public List<Account> Accounts { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Operation> Operations { get; set; }

        public List<T> LoadData<T>();

        public bool SaveData<T>(List<T> data);
    }
}
