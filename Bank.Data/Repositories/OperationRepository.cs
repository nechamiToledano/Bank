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
        readonly DataContext _dataContext;
        public OperationRepository(DataContext dataContext)
        {

            _dataContext = dataContext;

        }

        public IEnumerable<Operation> GetAllAsync()
        {
            List<Operation> Operations = _dataContext.LoadData<Operation>();
            return _dataContext.LoadData<Operation>() == null ? null : Operations.FindAll(o => o.Type==OperationType.Deposit );
        }
        public Operation GetByIdAsync(int id)
        {
            List<Operation> operations = _dataContext.LoadData<Operation>();


            return operations == null ? null : operations.Find(operation => operation.Id == id);

        }
        public bool AddAsync(Operation Operation)
        {
            List<Operation> operations = _dataContext.LoadData<Operation>();

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
            List<Operation> operations = _dataContext.LoadData<Operation>();
            if (operations == null) { return false; }
            Operation operation = operations.Find(operation => operation.Id == updateddOperation.Id);
            if (operation == null)
                return false;
         
            _dataContext.SaveData(operations);

            return true;
        }
        public bool DeleteAsync(int id)
        {
            List<Operation> operations = _dataContext.LoadData<Operation>();
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
