using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq.Expressions;
using DNekrasovDB.Models;

namespace DNekrasovDB.UnitOfWork.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken token);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddRangeasync(IEnumerable<T> obj);

        /*IQueryable<T> FindBy(Expression<Func<T, bool>> searchPredicate,
            params Expression<Func<T, object>>[] includesPredicate);

        Task AddAsync(T objects);

        void UpDate(T objects);

        Task Delete(Guid id);*/

    }
}
