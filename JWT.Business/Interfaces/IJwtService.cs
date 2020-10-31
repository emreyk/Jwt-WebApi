using JWT.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}
