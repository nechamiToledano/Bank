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
    public class CreditCardService : ICreditCardService
    {
        readonly IRepository<CreditCard> _creditCardRepository;
        public CreditCardService(IRepository<CreditCard> creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public CreditCard AddCard(CreditCard CreditCard)
        {
            return _creditCardRepository.AddAsync(CreditCard);
        }

        public bool DeleteCard(int id)
        {
            return _creditCardRepository.DeleteAsync(id);
        }

        public CreditCard GetCard(int id)
        {
            return _creditCardRepository.GetByIdAsync(id);
        }

        public IEnumerable<CreditCard> GetAllCards()
        {
            return _creditCardRepository.GetAllAsync();
        }

        public CreditCard UpdateCard(int id, CreditCard CreditCard)
        {
            return _creditCardRepository.UpdateAsync(id,CreditCard);
        }
    }
}
