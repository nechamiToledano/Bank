
using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bank.Api.Controllers
{
    [Route("Bank/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // GET: /Bank/Loan
        [HttpGet]
        public ActionResult<IEnumerable<Loan>> Get()
        {
            var loans = (List<Loan>)_loanService.GetAllLoans();
            return loans == null ? NotFound() : loans;
        }

        // GET: /Bank/Loan/{id}
        [HttpGet("{id}")]

        public ActionResult<Loan> GetLoanById(int id)
        {
            var loan = _loanService.GetLoan(id);
            return loan == null ? NotFound() : loan;
        }

        // POST: /Bank/Loan/NewLoan
        [HttpPost]
        public ActionResult<Loan> AddLoan([FromBody] Loan loan)
        {
            Loan newLoan = _loanService.AddLoan(loan);
            return newLoan != null ? newLoan : NotFound();
        }

        // PUT: /Bank/Loan/MyLoan/{id}
        [HttpPut("{id}")]


        public ActionResult<Loan> UpdateLoan(int id, [FromBody] Loan updatedLoan)
        {
            Loan loan = _loanService.UpdateLoan(id, updatedLoan);
            return loan != null ? loan : NotFound();

        }
        [HttpDelete]
        public ActionResult<bool> DeleteLoan(int id)
        {

            return _loanService.DeleteLoan(id) ? true : NotFound();

        }
    }
}
