using Bank.Core.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _dbSet;
        private readonly IRepositManger _repositManger;
        public Repository(DataContext dataContext, IRepositManger repositManger)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
            _repositManger = repositManger;
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _dbSet.ToList();
        }

        public T GetByIdAsync(int id)
        {
            return  _dbSet.Find(id);
        }

        public  T AddAsync(T entity)
        {
             _dbSet.Add(entity);
             _repositManger.Save();
            return entity;
        }

        public  T UpdateAsync(int id,T entity)
        {

           // Attach the entity to the DbContext if it's not already tracked
            _dbSet.Attach(entity);

            // Get the entity's entry in the DbContext
            //var entry = _dataContext.Entry(_dbSet.Find(id));

            var existingEntity = _dbSet.Find(id);
            if (existingEntity == null)
            {
                return null;
            }

            var entry = _dataContext.Entry(existingEntity);


            // Iterate over all properties of the entity
            foreach (var property in entry.Properties) 
            {
                var currentValue = property.CurrentValue;
                var propertyType = property.Metadata.ClrType;

                // Check if the property value is not null for reference types
                // or not equal to its default value for value types
                if (currentValue != null && !IsDefaultValue(currentValue, propertyType))
                {
                    if(!property.Metadata.IsKey())
                        property.IsModified = true;
                }
            }
             _repositManger.Save();
            return _dbSet.Find(id);
            // Save changes to the database
           
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


            return _repositManger.Save();
        }
    }
}
