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
    public class LoanRepository : IRepository<Loan>
    {
        readonly DataContext _dataContext;
        public LoanRepository(DataContext dataContext)
        {

            _dataContext = dataContext;

        }

        public IEnumerable<Loan> GetAllAsync()
        {
            List<Loan> Loans = _dataContext.LoadData<Loan>();
            return _dataContext.LoadData<Loan>() == null ? null : Loans.FindAll(l => l.Status == LoanStatus.Active);
        }
        public Loan GetByIdAsync(int id)
        {
            List<Loan> loans = _dataContext.LoadData<Loan>();


            return loans == null ? null : loans.Find(loan =>loan.Id == id);

        }
        public bool AddAsync(Loan loan)
        {
            List<Loan> loans = _dataContext.LoadData<Loan>();

            if (loans != null)
            {
                loans.Add(loan);
                _dataContext.SaveData(loans);
                return true;
            }
            return false;
        }
        public bool UpdateAsync(Loan updatedLoan)
        {
            List<Loan> loans = _dataContext.LoadData<Loan>();
            if (loans == null) { return false; }
            Loan Loan = loans.Find(loan => loan.Id == updatedLoan.Id);
            if (Loan == null)
                return false;
            updatedLoan.Status = updatedLoan.Status;
            updatedLoan.Amount = updatedLoan.Amount;
            updatedLoan.DateIssued = updatedLoan.DateIssued;
            updatedLoan.CustomerId = updatedLoan.CustomerId;
            updatedLoan.MaturityDate = updatedLoan.MaturityDate;
            updatedLoan.InterestRate = updatedLoan.InterestRate;
            updatedLoan.OutstandingBalance = updatedLoan.OutstandingBalance;

            _dataContext.SaveData(loans);

            return true;
        }
        public bool DeleteAsync(int id)
        {
            List<Loan> loans = _dataContext.LoadData<Loan>();
            if (loans == null) { return false; }

            var Loan = loans.Find(loan => loan.Id == id);
            if (Loan == null)
                return false;
            loans.Remove(Loan);
            _dataContext.SaveData(loans);
            return true;
        }
    }
}
