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
    public class AccountService : IAccountService
    {
        readonly IRepository<Account> _accountRepository;
        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account AddAccount(Account account)
        {
            return _accountRepository.AddAsync(account);
        }

        public bool DeleteAccount(int id)
        {
            return _accountRepository.DeleteAsync(id);
        }

        public Account GetAccount(int id)
        {
   return _accountRepository.GetByIdAsync(id);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAsync();
        }

        public Account UpdateAccount(int id, Account account)
        {
            return _accountRepository.UpdateAsync(id, account);
        }
    }
}
