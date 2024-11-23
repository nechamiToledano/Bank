using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.InterfaceRepository;
using Bank.Core.InterfaceService;
using System.Security.Principal;

namespace Bank.Data.Repositories
{
    public class CreditCardRepository : IRepository<CreditCard>
    {
        readonly IDataContext _dataContext;
        public CreditCardRepository(IDataContext dataContext)
        {

            _dataContext = dataContext;

        }

        public IEnumerable<CreditCard> GetAllAsync()
        {
            List<CreditCard> creditCards = _dataContext.CreditCards;
            return creditCards== null ? null : creditCards.FindAll(c => c.Status == CreditCardStatus.Active);
        }
        public CreditCard GetByIdAsync(int id)
        {
            List<CreditCard> creditCards = _dataContext.CreditCards;


            return creditCards == null ? null : creditCards.Find(creditCard => creditCard.Id == id);

        }
        public bool AddAsync(CreditCard CreditCard)
        {
            List<CreditCard> creditCards = _dataContext.CreditCards;

            if (creditCards != null)
            {
                creditCards.Add(CreditCard);
                _dataContext.SaveData(creditCards);
                return true;
            }
            return false;
        }
        public bool UpdateAsync(CreditCard updatedCreditCard)
        {
            List<CreditCard> creditCards = _dataContext.CreditCards;
            if (creditCards == null) { return false; }
            CreditCard creditCard = creditCards.Find(creditCard => creditCard.Id == updatedCreditCard.Id);
            if (creditCard == null)
                return false;
            creditCard.Status = updatedCreditCard.Status;
            creditCard.CreditLimit = updatedCreditCard.CreditLimit;
            creditCard.AvailableBalance = updatedCreditCard.AvailableBalance;
            creditCard.AccountNumber = updatedCreditCard.AccountNumber;
            creditCard.CustomerID = updatedCreditCard.CustomerID;
            creditCard.Type = updatedCreditCard.Type;


            return true;
        }
        public bool DeleteAsync(int id)
        {
            List<CreditCard> CreditCards = _dataContext.CreditCards;
            if (CreditCards == null) { return false; }

            var CreditCard = CreditCards.Find(creditCard => creditCard.Id == id);
            if (CreditCard == null)
                return false;
            CreditCards.Remove(CreditCard);
            _dataContext.SaveData(CreditCards);
            return true;
        }
    }
}
