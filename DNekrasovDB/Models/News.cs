using System;
using System.Collections.Generic;

namespace DNekrasovDB.Models
{
    public class News : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public IEnumerable<Comments> Comments { get; set; }

        public Guid MagazineId { get; set; }

        public Magazine Magazine { get; set; }
    }
}
