using GoodNewsBlog.Data;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodNewsBlog.UserService
{
    public class AuthenticateResponcse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string JwtToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }

        public AuthenticateResponcse(JwtAppUser user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            Name = user.Email;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;

        }
    }
}
