using JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.DataAccess.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class,ITable, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
