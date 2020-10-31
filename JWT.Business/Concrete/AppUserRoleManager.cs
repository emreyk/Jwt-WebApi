using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Business.Concrete
{
    public class AppUserRoleManager:IAppUserRoleService
    {
        private readonly IAppUserRoleDal _appUserRole;
        public AppUserRoleManager(IAppUserRoleDal appUserRole)
        {
            _appUserRole = appUserRole;
        }

        public async Task AddAsync(AppUserRole entity)
        {
            await _appUserRole.AddAsync(entity);
        }

        public async Task<List<AppUserRole>> GetAllAsync()
        {
            return await _appUserRole.GetAllAsync();
        }

        public async Task<AppUserRole> GetByIdAsync(int id)
        {
            return await _appUserRole.GetByIdAsync(id);
        }

        public async Task RemoveAsync(AppUserRole entity)
        {
            await _appUserRole.RemoveAsync(entity);
        }

        public async Task UpdateAsync(AppUserRole entity)
        {
            await _appUserRole.RemoveAsync(entity);
        }
    }
}
