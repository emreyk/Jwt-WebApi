using JWT.Entities.Concrate;
using JWT.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<AppUser> FindByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(AppUserLoginDto appUserLoginDto);
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
