using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNekrasovDB.Models.DB;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace DNekrasovDB.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly GoodNewsContext _goodNewsContext;
        private readonly DbSet<T> _dbset;

        public Repository(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
            _dbset = _goodNewsContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbset.FirstOrDefaultAsync(news => news.Id.Equals(id), token);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> searchPredicate,
            params Expression<Func<T, object>>[] includesPredicate)
        {
            var result = _dbset.Where(searchPredicate);
            if (includesPredicate.Any())
            {
                result = includesPredicate
                    .Aggregate(result, (current, include) => current.Include(include));
            }

            return result;
        }

        public async Task AddAsync(T objects)
        {
            var result = await _dbset.AddAsync(objects);
        }

        public async Task AddRangeasync(IEnumerable<T> obj)
        {
            await _dbset.AddRangeAsync(obj);
        }

        public void UpDate(T objects)
        {
            var result = _dbset.Update(objects);
        }

        public async Task Delete(Guid id)
        {
             _dbset.Remove(await _dbset.FirstOrDefaultAsync(entity => entity.Id.Equals(id)));
        }

        
    }
}
