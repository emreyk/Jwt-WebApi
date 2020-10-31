using Jwt.DataAccess.Concrete.EntityFrameworkCore.Context;
using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppRoleRepository : EfGenericRepository<AppRole>, IAppRoleDal
    {
        public async Task<AppRole> FindByNameAsync(string roleName)
        {
            var contex = new JwtContext();
             return await contex.AppRoles.Where(x => x.Name == roleName).FirstOrDefaultAsync();
        }

        
    }
}
