
using Bank.Core.Entities;
using Bank.Core.InterfaceService;
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

        // GET: /Bank/CreditCard
        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> Get()
        {
            var creditCards = (List<CreditCard>)_creditCardService.GetAllCards();
            return creditCards == null ? NotFound() : creditCards;
        }

        // GET: /Bank/CreditCard/{id}
        [HttpGet("{id}")]

        public ActionResult<CreditCard> GetCreditCardById(int id)
        {
            var creditCard = _creditCardService.GetCard(id);
            return creditCard == null ? NotFound() : creditCard;
        }

        // POST: /Bank/CreditCard/NewCreditCard
        [HttpPost]
        public ActionResult<CreditCard> AddCreditCard([FromBody] CreditCard creditCard)
        {
            CreditCard newCreditCard = _creditCardService.AddCard(creditCard);
            return newCreditCard != null ? newCreditCard : NotFound();
        }

        // PUT: /Bank/CreditCard/MyCreditCard/{id}
        [HttpPut("{id}")]


        public ActionResult<CreditCard> UpdateCreditCard(int id, [FromBody] CreditCard updatedCreditCard)
        {
            CreditCard creditCard = _creditCardService.UpdateCard(id, updatedCreditCard);
            return creditCard != null ? creditCard : NotFound();

        }
        [HttpDelete]
        public ActionResult<bool> DeleteCreditCard(int id)
        {

            return _creditCardService.DeleteCard(id) ? true : NotFound();

        }
    }
}
