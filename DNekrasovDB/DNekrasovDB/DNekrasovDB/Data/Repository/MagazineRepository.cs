using DNekrasovDB.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.Repository
{
    public class MagazineRepository : Repository<Magazine>
    {
        public MagazineRepository(GoodNewsContext goodNewsContext) : base(goodNewsContext)
        {
        }
    }
}
