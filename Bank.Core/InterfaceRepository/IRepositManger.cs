using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceRepository
{
    public interface IRepositManger<T> where T:class
    {
        IRepository<T> Repository { get; }

        bool Save();
    }
}
