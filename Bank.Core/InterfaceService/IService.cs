using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceService
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAllAsync();
        T GetAsync(int id);
        bool AddAsync(T entity);
        bool UpdateAsync(T entity);
        bool DeleteAsync(int id);

    }
}
