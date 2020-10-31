﻿using JWT.Entities.Concrate;
using JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.DataAccess.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> FindByNameAsync(string roleName);
    }
}
