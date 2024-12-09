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
    public class OperationService : IOperationService
    {
        readonly IRepository<Operation> _operationRepository;
        public OperationService(IRepository<Operation> operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public bool AddOperation(Operation operation)
        {
            return _operationRepository.AddAsync(operation);
        }

        public bool DeleteOperation(int id)
        {
            return _operationRepository.DeleteAsync(id);
        }

        public Operation GetOperation(int id)
        {
            return _operationRepository.GetByIdAsync(id);
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _operationRepository.GetAllAsync();
        }

        public bool UpdateOperation(Operation operation)
        {
            return _operationRepository.UpdateAsync(operation);
        }
    }
}
