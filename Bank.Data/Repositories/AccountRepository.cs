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
    public class AccountRepository : IRepository<Account>
    {
        readonly DataContext _dataContext;
        public AccountRepository(DataContext dataContext)
        {

            _dataContext = dataContext;

        }
      
        public IEnumerable<Account> GetAllAsync() {
            List<Account> accounts = _dataContext.LoadData<Account>();
           return _dataContext.LoadData<Account>() == null?null:accounts.FindAll(a => a.Status == AccountStatus.Active);
        }
        public Account GetByIdAsync(int id)
        {
            List<Account> accounts = _dataContext.LoadData<Account>();
            

            return accounts==null?null: accounts.Find(account => account.Id == id);

        }
       public bool AddAsync(Account account) {
            List<Account> accounts = _dataContext.LoadData<Account>();

            if (accounts != null)
            {
                accounts.Add(account);
                _dataContext.SaveData(accounts);
                return true;
            }
            return false;
        }
       public bool UpdateAsync(Account newAccount) {
            List<Account> accounts = _dataContext.LoadData<Account>();
            if (accounts == null) { return false; }
            Account account = accounts.Find(account => account.Id == newAccount.Id);
            if (account == null)
                return false;
            account.Status = newAccount.Status;
            account.Number = newAccount.Number;
            account.Balance = newAccount.Balance;
            account.BranchId = newAccount.BranchId;
            account.HolderId = newAccount.HolderId;
            _dataContext.SaveData(accounts);

            return true;
        }
       public bool DeleteAsync(int id) {
            List<Account> accounts = _dataContext.LoadData<Account>();
            if (accounts == null) { return false; }

            var account = accounts.Find(account => account.Id == id);
            if (account == null)
                return false;
            accounts.Remove(account);
            _dataContext.SaveData(accounts);
            return true;
        }
    }
}
