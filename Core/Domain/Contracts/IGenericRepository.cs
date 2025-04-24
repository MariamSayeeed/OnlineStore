using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity , TKey> where TEntity : BaseEntity<TKey> 
    {
        Task <IEnumerable<TEntity>> GetAllAsync(bool trackChange = false);
        Task <IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey> spec , bool trackChange = false);

        Task <TEntity?> GetAsync(TKey id);
        Task <TEntity?> GetAsync(ISpecifications<TEntity, TKey> spec, TKey id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey entity);
        Task <int> CountAsync(ISpecifications<TEntity , TKey> spec);
        
    }
}
