using Bank.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class RepositManager:IRepositManger
    {
      
            private readonly DataContext _context;

            public RepositManager(DataContext context)
            {
                _context = context;
            }

            public bool Save()
            {
               return _context.SaveChanges()>0;
            }
        }
    }
