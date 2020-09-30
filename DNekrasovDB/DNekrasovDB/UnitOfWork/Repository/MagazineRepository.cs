using DNekrasovDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.UnitOfWork.Repository
{
    public class MagazineRepository : Repository<Magazine>
    {
        public MagazineRepository(GoodNewsContext goodNewsContext) : base(goodNewsContext)
        {
        }
    }
}
