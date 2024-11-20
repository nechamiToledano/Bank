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
    public class OperationService : IService<Operation>
    {
        readonly IRepository<Operation> _OperationRepository;
        public OperationService(IRepository<Operation> OperationRepository)
        {
            _OperationRepository = OperationRepository;
        }
        public IEnumerable<Operation> GetAllAsync()
        {

            return _OperationRepository.GetAllAsync();
        }

        public Operation GetAsync(int id)
        {
            return _OperationRepository.GetByIdAsync(id);
        }

        public bool AddAsync(Operation Operation)
        {
            return _OperationRepository.AddAsync(Operation);
        }

        public bool UpdateAsync(Operation Operation)
        {
            return _OperationRepository.UpdateAsync(Operation);
        }

        public bool DeleteAsync(int id)
        {
            return _OperationRepository.DeleteAsync(id);
        }
    }
}
