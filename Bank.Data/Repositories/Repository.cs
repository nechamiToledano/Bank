using Bank.Core.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _dbSet.ToList();
        }

        public T GetByIdAsync(int id)
        {
            return  _dbSet.Find(id);
        }

        public  bool AddAsync(T entity)
        {
             _dbSet.AddAsync(entity);
            return  _dataContext.SaveChanges() > 0;
        }

        public  bool UpdateAsync(T entity)
        {
            // Attach the entity to the DbContext if it's not already tracked
            _dbSet.Attach(entity);

            // Get the entity's entry in the DbContext
            var entry = _dataContext.Entry(entity);

            // Iterate over all properties of the entity
            foreach (var property in entry.Properties)
            {
                var currentValue = property.CurrentValue;
                var propertyType = property.Metadata.ClrType;

                // Check if the property value is not null for reference types
                // or not equal to its default value for value types
                if (currentValue != null && !IsDefaultValue(currentValue, propertyType))
                {
                    property.IsModified = true;
                }
            }

            // Save changes to the database
            return  _dataContext.SaveChanges() > 0;
        }

        // Helper method to check if a value equals the default for its type
        private bool IsDefaultValue(object value, Type type)
        {
            if (type.IsValueType)
            {
                return value.Equals(Activator.CreateInstance(type));
            }

            return false; // Reference types: null is the default
        }


        public  bool DeleteAsync(int id)
        {
            var entity =  GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            return _dataContext.SaveChanges() > 0;
        }
    }
}
