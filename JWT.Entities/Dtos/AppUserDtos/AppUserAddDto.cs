using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
