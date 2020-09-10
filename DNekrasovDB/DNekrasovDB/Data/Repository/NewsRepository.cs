using DNekrasovDB.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.Repository
{
    public class NewsRepository : Repository<News>
    {
        public NewsRepository(GoodNewsContext goodNewsContext) : base(goodNewsContext)
        {
        }



        public override async Task<IEnumerable<News>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public override async Task AddRangeasync(IEnumerable<News> obj)
        {
            await _dbset.AddRangeAsync(obj);
        }
    }
}
