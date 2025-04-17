using Domain.Contracts;
using Domain.Models;
using Presistance.Data;
using Presistance.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        //private readonly Dictionary<string, object> _repositories;
        private readonly ConcurrentDictionary<string, object> _repositories;


        public UnitOfWork(StoreDbContext context) 
        {
            _context = context;
            //_repositories = new Dictionary<string, object>();
            _repositories = new ConcurrentDictionary<string, object>();
        }

        //----------- Way 1
        //public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        //{
        //    //return new GenericRepository<TEntity, TKey>(_context);
        //    var type = typeof(TEntity).Name;
        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repository = new GenericRepository<TEntity , TKey>(_context);
        //       _repositories.Add(type,repository);
        //    }
        //    return (IGenericRepository<TEntity, TKey>) _repositories[type];
        //}

        //----------- Way 2
        //public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        //{
        //    return (IGenericRepository<TEntity, TKey>) _repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity  , TKey>(_context));
        //}

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        => (IGenericRepository<TEntity, TKey>)_repositories
            .GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_context));
        


        public async Task<int> SaveChangesAsync()  // == CompleteAsync
        {
            return await _context.SaveChangesAsync();
        }
    }
}
