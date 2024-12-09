using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceService
{
    public interface ILoanService
    {
        IEnumerable<Loan> GetAllLoans();
        Loan GetLoan(int id);
        bool AddLoan(Loan loan);
        bool UpdateLoan(Loan loan   );
        bool DeleteLoan(int id);
    }
}
