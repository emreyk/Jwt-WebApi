using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole>, IAppUserRoleDal
    {
    }
}
