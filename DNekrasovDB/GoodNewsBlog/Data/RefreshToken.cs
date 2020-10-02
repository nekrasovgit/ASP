using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodNewsBlog.Data
{
    
    public class RefreshToken
    {

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        public DateTime Created { get; set; }

        public DateTime Revoked { get; set; }

        public string ReplacedByToken { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;

        public string UserId { get; set; }

        public JwtAppUser JwtAppUser { get; set; }

        //добавить в базу
    }
}
