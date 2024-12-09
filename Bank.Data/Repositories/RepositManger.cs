using Bank.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class RepositManager<T>:IRepositManger<T> where T : class
    {
      
            private readonly DataContext _context;
            public IRepository<T> Repository { get; }

            public RepositManager(DataContext context, IRepository<T> repository)
            {
                _context = context;
                Repository = repository;
            }

            public bool Save()
            {
               return _context.SaveChanges()>0;
            }
        }
    }
