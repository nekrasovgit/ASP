using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodNewsBlog.Data
{
    public class JwtAppUser : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
