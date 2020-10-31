using Jwt.DataAccess.Interfaces;
using JWT.Business.StringInfos;
using JWT.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.UI
{
    public class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
       {
          
            var adminRole = await appRoleService.FindByNameAsync(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.AddAsync(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByNameAsync(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.AddAsync(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserNameAsync("emre");
            if (adminUser == null)
            {
                await appUserService.AddAsync(new AppUser
                {
                    FullName = "emre yüksek",
                    UserName = "emre",
                    Password = "123"
                });

                var role = await appRoleService.FindByNameAsync(RoleInfo.Admin);
                var admin = await appUserService.FindByUserNameAsync("emre");

                await appUserRoleService.AddAsync(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
