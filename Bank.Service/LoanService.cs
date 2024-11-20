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
    public class LoanService : IService<Loan>
    {
        readonly IRepository<Loan> _LoanRepository;
        public LoanService(IRepository<Loan> LoanRepository)
        {
            _LoanRepository = LoanRepository;
        }
        public IEnumerable<Loan> GetAllAsync()
        {

            return _LoanRepository.GetAllAsync();
        }

        public Loan GetAsync(int id)
        {
            return _LoanRepository.GetByIdAsync(id);
        }

        public bool AddAsync(Loan Loan)
        {
            return _LoanRepository.AddAsync(Loan);
        }

        public bool UpdateAsync(Loan Loan)
        {
            return _LoanRepository.UpdateAsync(Loan);
        }

        public bool DeleteAsync(int id)
        {
            return _LoanRepository.DeleteAsync(id);
        }
    }
}
