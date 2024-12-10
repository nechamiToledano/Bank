
using Bank.Core.Entities;
using Bank.Core.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bank.Api.Controllers
{
    [Route("Bank/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        // GET: /Bank/Operation
        [HttpGet]
        public ActionResult<IEnumerable<Operation>> Get()
        {
            var operations = (List<Operation>)_operationService.GetAllOperations();
            return operations == null ? NotFound() : operations;
        }

        // GET: /Bank/Operation/{id}
        [HttpGet("{id}")]

        public ActionResult<Operation> GetOperationById(int id)
        {
            var operation = _operationService.GetOperation(id);
            return operation == null ? NotFound() : operation;
        }

        // POST: /Bank/Operation/NewOperation
        [HttpPost]
        public ActionResult<Operation> AddOperation([FromBody] Operation operation)
        {
            Operation newOperation = _operationService.AddOperation(operation);
            return newOperation != null ? newOperation : NotFound();
        }

        // PUT: /Bank/Operation/MyOperation/{id}
        [HttpPut("{id}")]


        public ActionResult<Operation> UpdateOperation(int id, [FromBody] Operation updatedOperation)
        {
            Operation operation = _operationService.UpdateOperation(id, updatedOperation);
            return operation!=null ? operation : NotFound();

        }
        [HttpDelete]
        public ActionResult<bool> DeleteOperation(int id)
        {

            return _operationService.DeleteOperation(id) ? true : NotFound();

        }
    }
}
