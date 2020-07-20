using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Models.DB
{
    public class Roles
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserRoles> UserRoles { get; set; }

        
    }
}
