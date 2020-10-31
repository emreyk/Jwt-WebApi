﻿using JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Entities.Dtos.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
