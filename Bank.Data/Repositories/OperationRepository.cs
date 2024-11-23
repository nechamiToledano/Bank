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
    public class OperationRepository : IRepository<Operation>
    {   
        readonly IDataContext _dataContext;
        public OperationRepository(IDataContext dataContext)
        {

            _dataContext = dataContext;

        }

        public IEnumerable<Operation> GetAllAsync()
        {
            List<Operation> operations = _dataContext.Operations;
            return operations == null ? null : operations.FindAll(o => o.Type==OperationType.Deposit );
        }
        public Operation GetByIdAsync(int id)
        {
            List<Operation> operations = _dataContext.Operations;


            return operations == null ? null : operations.Find(operation => operation.Id == id);

        }
        public bool AddAsync(Operation Operation)
        {
            List<Operation> operations = _dataContext.Operations;

            if (operations != null)
            {
                operations.Add(Operation);
                _dataContext.SaveData(operations);
                return true;
            }
            return false;
        }
        public bool UpdateAsync(Operation updateddOperation)
        {
            List<Operation> operations = _dataContext.Operations;
            if (operations == null) { return false; }
            Operation operation = operations.Find(operation => operation.Id == updateddOperation.Id);
            if (operation == null)
                return false;
         
            _dataContext.SaveData(operations);

            return true;
        }
        public bool DeleteAsync(int id)
        {
            List<Operation> operations = _dataContext.Operations;
            if (operations == null) { return false; }

            var Operation = operations.Find(operation => operation.Id == id);
            if (Operation == null)
                return false;
            operations.Remove(Operation);
            _dataContext.SaveData(operations);
            return true;
        }
    }
}
