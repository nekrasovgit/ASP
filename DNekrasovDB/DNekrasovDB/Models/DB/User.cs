using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Models.DB
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public IEnumerable<UserRoles> UserRoles { get; set; }

        public IEnumerable<Comments> Comments { get; set; }

    }
}
