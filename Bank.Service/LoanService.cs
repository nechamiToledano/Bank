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
    public class LoanService : ILoanService
    {
        readonly IRepository<Loan> _loanRepository;
        public LoanService(IRepository<Loan> loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public bool AddLoan(Loan loan)
        {
            return _loanRepository.AddAsync(loan);
        }

        public bool DeleteLoan(int id)
        {
            return _loanRepository.DeleteAsync(id);
        }

        public Loan GetLoan(int id)
        {
            return _loanRepository.GetByIdAsync(id);
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _loanRepository.GetAllAsync();
        }

        public bool UpdateLoan(Loan loan)
        {
            return _loanRepository.UpdateAsync(loan);
        }
    }
}
