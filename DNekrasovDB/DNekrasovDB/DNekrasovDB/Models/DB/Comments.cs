using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Models.DB
{
    public class Comments : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }
        
        public Guid UserId { get; set; }

        public Guid NewsId { get; set; }

        public User User { get; set; }

        public News News { get; set; }
    }
}
