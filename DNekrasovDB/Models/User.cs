using System;
using System.Collections.Generic;

namespace DNekrasovDB.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<UserRoles> UserRoles { get; set; }

        public IEnumerable<Comments> Comments { get; set; }

        public IEnumerable<RefreshToken> RefreshTokens { get; set; }

    }
}
