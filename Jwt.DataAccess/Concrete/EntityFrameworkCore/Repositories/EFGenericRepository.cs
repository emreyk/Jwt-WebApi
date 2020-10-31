using Jwt.DataAccess.Concrete.EntityFrameworkCore.Context;
using Jwt.DataAccess.Interfaces;
using JWT.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new JwtContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

      
        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().ToListAsync();
        }

      
        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new JwtContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new JwtContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
