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
    public class CreditCardService : IService<CreditCard>
    {
        readonly IRepository<CreditCard> _CreditCardRepository;
        public CreditCardService(IRepository<CreditCard> CreditCardRepository)
        {
            _CreditCardRepository = CreditCardRepository;
        }
        public IEnumerable<CreditCard> GetAllAsync()
        {

            return _CreditCardRepository.GetAllAsync();
        }

        public CreditCard GetAsync(int id)
        {
            return _CreditCardRepository.GetByIdAsync(id);
        }

        public bool AddAsync(CreditCard CreditCard)
        {
            return _CreditCardRepository.AddAsync(CreditCard);
        }

        public bool UpdateAsync(CreditCard CreditCard)
        {
            return _CreditCardRepository.UpdateAsync(CreditCard);
        }

        public bool DeleteAsync(int id)
        {
            return _CreditCardRepository.DeleteAsync(id);
        }
    }
}
