
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
         readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> GetAllCreditCards()
        {
            var creditCards =( List<CreditCard>)_creditCardService.GetAllCards();
            return creditCards == null ? NotFound() : creditCards;
        }

        [HttpGet("{id}")]
     
        public ActionResult<CreditCard> GetCreditCardById(int id)
        {
            var card = _creditCardService.GetCard(id);
            return card == null ? NotFound() : card;
        }

        [HttpPost]
        public ActionResult<bool> AddCreditCard([FromBody]CreditCard creditCard)
        {
           return  _creditCardService.AddCard(creditCard)?true:NotFound();
           
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdateCreditCard(CreditCard creditCard)
        {

            return _creditCardService.UpdateCard(creditCard)?true:NotFound();
            
        }

        [HttpDelete()]
        public ActionResult<bool> DeleteCreditCard(int id)
        {
          return  _creditCardService.DeleteCard(id)?true:NotFound();
           
        }
    }
}
