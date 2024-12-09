
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
        [HttpGet("{number}")]

        public ActionResult<Loan> GetLoanById(int id)
        {
            var loan = _loanService.GetLoan(id);
            return loan == null ? NotFound() : loan;
        }

        // POST: /Bank/Loan/NewLoan
        [HttpPost]
        public ActionResult<bool> AddLoan([FromBody] Loan loan)
        {

            return _loanService.AddLoan(loan) ? true : NotFound();
        }

        // PUT: /Bank/Loan/MyLoan/{id}
        [HttpPut]


        public ActionResult<bool> UpdateLoan([FromBody] Loan loan)
        {

            return _loanService.UpdateLoan(loan) ? true : NotFound();

        }
        [HttpDelete]
        public ActionResult<bool> DeleteLoan(int id)
        {

            return _loanService.DeleteLoan(id) ? true : NotFound();

        }
    }
}
