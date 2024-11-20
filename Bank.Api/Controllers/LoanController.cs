
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
        readonly IService<Loan> _loanService;

        public LoanController(IService<Loan> loanService)
        {
            _loanService = loanService;
        }

        // GET: /Bank/Loan
        [HttpGet]
        public ActionResult<IEnumerable<Loan>> Get()
        {
            var loans = (List<Loan>)_loanService.GetAllAsync();
            return loans == null ? NotFound() : loans;
        }

        // GET: /Bank/Loan/{id}
        [HttpGet("{number}")]

        public ActionResult<Loan> GetLoanById(int id)
        {
            var loan = _loanService.GetAsync(id);
            return loan == null ? NotFound() : loan;
        }

        // POST: /Bank/Loan/NewLoan
        [HttpPost]
        public ActionResult<bool> AddLoan([FromBody] Loan loan)
        {

            return _loanService.AddAsync(loan) ? true : NotFound();
        }

        // PUT: /Bank/Loan/MyLoan/{id}
        [HttpPut]


        public ActionResult<bool> UpdateLoan([FromBody] Loan loan)
        {

            return _loanService.UpdateAsync(loan) ? true : NotFound();

        }
        [HttpDelete]
        public ActionResult<bool> DeleteLoan(int id)
        {

            return _loanService.DeleteAsync(id) ? true : NotFound();

        }
    }
}
