
using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bank.Api.Controllers
{
    [Route("Bank/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
         readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: /Bank/Account
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get() {
            var accounts = (List<Account>)_accountService.GetAllAccounts();
            return accounts == null ? NotFound() : accounts;
        }

        // GET: /Bank/Account/{id}
        [HttpGet("{id}")]

        public ActionResult<Account> GetAccountById(int id)
        {
            var account = _accountService.GetAccount(id);
            return account == null ? NotFound() : account;
        }

        // POST: /Bank/Account/NewAccount
        [HttpPost]
        public ActionResult<bool> AddAccount([FromBody] Account account)
        {
            
            return _accountService.AddAccount(account)?true:NotFound();
        }

        // PUT: /Bank/Account/MyAccount/{id}
        [HttpPut]
   

        public ActionResult<bool> UpdateAccount([FromBody] Account account)
        {
          
            return _accountService.UpdateAccount(account) ? true : NotFound();
             
        }
        [HttpDelete]
        public ActionResult<bool> DeleteAccount(int id)
        {
           
            return _accountService.DeleteAccount(id) ? true : NotFound();

        }
    }
}
