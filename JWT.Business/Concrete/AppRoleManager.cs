using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Business.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDal _appRole;
        public AppRoleManager(IAppRoleDal appRole)
        {
            _appRole = appRole;
        }

        public async Task AddAsync(AppRole entity)
        {
            await _appRole.AddAsync(entity);
        }

        public async Task<AppRole> FindByNameAsync(string roleName)
        {
           return await _appRole.FindByNameAsync(roleName);
        }

        public async Task<List<AppRole>> GetAllAsync()
        {
            return await _appRole.GetAllAsync();
        }

        public async Task<AppRole> GetByIdAsync(int id)
        {
            return await _appRole.GetByIdAsync(id);
        }

        public async Task RemoveAsync(AppRole entity)
        {
            await _appRole.RemoveAsync(entity);
        }

        public async Task UpdateAsync(AppRole entity)
        {
            await _appRole.RemoveAsync(entity);
        }
    }
}
