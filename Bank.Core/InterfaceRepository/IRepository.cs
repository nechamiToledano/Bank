using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceRepository
{
    public interface IRepository<T> where T : class
    {
       IEnumerable<T> GetAllAsync();
       T GetByIdAsync(int id);
       T AddAsync(T entity);
       T UpdateAsync(int id,T entity);
       bool DeleteAsync(int id);
    }
}
