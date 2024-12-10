using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceService
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccount(int id);
        Account AddAccount(Account account);
        Account UpdateAccount(int id, Account account);
        bool DeleteAccount(int id);
    }
}
