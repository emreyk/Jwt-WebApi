using JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
