using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using DNekrasovDB.Models;

namespace DNekrasovDB.UnitOfWork.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly GoodNewsContext _goodNewsContext;
        protected readonly DbSet<T> _dbset;

        public Repository(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
            _dbset = _goodNewsContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbset.FirstOrDefaultAsync(news => news.Id.Equals(id), token);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public virtual async Task AddRangeasync(IEnumerable<T> obj)
        {
            await _dbset.AddRangeAsync(obj);
        }

    }
}
