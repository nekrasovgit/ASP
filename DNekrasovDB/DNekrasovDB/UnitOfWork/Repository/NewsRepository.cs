using DNekrasovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DNekrasovDB.UnitOfWork.Repository
{
    public class NewsRepository : Repository<News>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public NewsRepository(GoodNewsContext goodNewsContext) : base(goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }



        public override async Task<IEnumerable<News>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public override async Task AddRangeasync(IEnumerable<News> news)
        {
            await _dbset.AddRangeAsync(news);
            await _goodNewsContext.SaveChangesAsync();
        }
    }
}
