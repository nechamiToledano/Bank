using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceRepository
{
    public interface IRepository<T> where T : class
    {


        IEnumerable<T> GetAllAsync();
        T GetByIdAsync(int id);
        bool AddAsync(T entity);
        bool UpdateAsync(T entity);
        bool DeleteAsync(int id);


    }
}
