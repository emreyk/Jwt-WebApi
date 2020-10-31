using Jwt.DataAccess.Concrete.EntityFrameworkCore.Context;
using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using JWT.Entities.Dtos.AppUserDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<bool> CheckPasswordAsync(AppUserLoginDto appUserLoginDto)
        {
            var context = new JwtContext();
            var appUser = await context.AppUsers.Where(x => x.UserName == appUserLoginDto.UserName).FirstOrDefaultAsync();
            return appUser.Password == appUserLoginDto.Password ? true : false;
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            var context = new JwtContext();
            return await context.AppUsers.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }


        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {

            using var context = new JwtContext();
            return await context.AppUsers.Join(context.AppUserRoles, u => u.Id, ur => ur.AppUserId, (user, userRole) => new
            {
                user = user,
                userRole = userRole
            }).Join(context.AppRoles, two => two.userRole.AppRoleId, r => r.Id, (twoTable, role) => new
            {
                user = twoTable.user,
                userRole = twoTable.userRole,
                role = role
            }).Where(I => I.user.UserName == userName).Select(I => new AppRole
            {
                Id = I.role.Id,
                Name = I.role.Name
            }).ToListAsync();
        }
    }
}
