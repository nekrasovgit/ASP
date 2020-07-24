using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Models.DB
{
    public class News
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public IEnumerable<Comments> Comments { get; set; }

        public Guid MagazineId { get; set; }

        public Magazine Magazine { get; set; }
    }
}
