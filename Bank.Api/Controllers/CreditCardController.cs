
using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using Bank.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bank.Api.Controllers
{
    [Route("Bank/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
         readonly IService<CreditCard> _creditCardService;

        public CreditCardController(IService<CreditCard> creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> GetAllCreditCards()
        {
            var creditCards =( List<CreditCard>)_creditCardService.GetAllAsync();
            return creditCards == null ? NotFound() : creditCards;
        }

        [HttpGet("{id}")]
     
        public ActionResult<CreditCard> GetCreditCardById(int id)
        {
            var card = _creditCardService.GetAsync(id);
            return card == null ? NotFound() : card;
        }

        [HttpPost]
        public ActionResult<bool> AddCreditCard([FromBody]CreditCard creditCard)
        {
           return  _creditCardService.AddAsync(creditCard)?true:NotFound();
           
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdateCreditCard(CreditCard creditCard)
        {

            return _creditCardService.UpdateAsync(creditCard)?true:NotFound();
            
        }

        [HttpDelete()]
        public ActionResult<bool> DeleteCreditCard(int id)
        {
          return  _creditCardService.DeleteAsync(id)?true:NotFound();
           
        }
    }
}
