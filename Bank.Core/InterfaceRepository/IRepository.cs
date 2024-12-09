using System.Collections.Generic;
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
