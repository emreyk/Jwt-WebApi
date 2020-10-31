using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using JWT.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Business.Concrete
{
    public class AppUserManager:IAppUserService
    {
        private readonly IAppUserDal _appUser;
        public AppUserManager(IAppUserDal appUser)
        {
            _appUser = appUser;
        }

        public async Task AddAsync(AppUser entity)
        {
            await _appUser.AddAsync(entity);
        }

        public async Task<bool> CheckPasswordAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _appUser.CheckPasswordAsync(appUserLoginDto);
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            return await _appUser.FindByUserNameAsync(userName);
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _appUser.GetAllAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _appUser.GetByIdAsync(id);
        }


        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            return await _appUser.GetRolesByUserNameAsync(userName);
        }

        public async Task RemoveAsync(AppUser entity)
        {
             await _appUser.RemoveAsync(entity);
        }

        public async Task UpdateAsync(AppUser entity)
        {
            await _appUser.UpdateAsync(entity);
        }
    }
}
