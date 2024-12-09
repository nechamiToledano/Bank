﻿using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceService
{
    public interface IOperationService
    {
        IEnumerable<Operation> GetAllOperations();
        Operation GetOperation(int id);
        bool AddOperation(Operation operation);
        bool UpdateOperation(Operation operation);
        bool DeleteOperation(int id);
    }
}