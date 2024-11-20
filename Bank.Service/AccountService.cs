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
    public class AccountService : IService<Account>
    {
        readonly IRepository<Account> _accountRepository;
        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IEnumerable<Account> GetAllAsync()
        {

            return _accountRepository.GetAllAsync();
        }

        public Account GetAsync(int id)
        {
            return _accountRepository.GetByIdAsync(id);
        }

        public bool AddAsync(Account account)
        {
            return _accountRepository.AddAsync(account);
        }

        public bool UpdateAsync(Account account)
        {
            return _accountRepository.UpdateAsync(account);
        }

        public bool DeleteAsync(int id)
        {
            return _accountRepository.DeleteAsync(id);
        }
    }
}
