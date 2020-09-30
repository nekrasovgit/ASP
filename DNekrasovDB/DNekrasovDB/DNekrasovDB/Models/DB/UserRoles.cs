using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Models.DB
{
    public class UserRoles : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid RolesId { get; set; }

        public User User { get; set; }

        public Roles Roles { get; set; }
    }
}
