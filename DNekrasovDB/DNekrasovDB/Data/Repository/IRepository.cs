using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNekrasovDB.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq.Expressions;

namespace DNekrasovDB.Data.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken token);

        IQueryable<T> FindBy(Expression<Func<T, bool>> searchPredicate,
            params Expression<Func<T, object>>[] includesPredicate);

        Task AddAsync(T objects);

        Task AddRangeasync(IEnumerable<T> obj);

        void UpDate(T objects);

        Task Delete(Guid id);

    }
}
