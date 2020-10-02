
using System.Threading.Tasks;
using System.Collections.Generic;
using DNekrasovDB.UnitOfWork.Repository;
using DNekrasovDB.Models;

namespace DNekrasovDB.UnitOfWork.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<News> NewsRepository { get; }

        IRepository<Magazine> MagazineRepository { get; }

        //public IEnumerable<News> GetAll();

       // public int AddRange(IEnumerable<News> collection);

        Task<int> SaveChangesAsync();
    }
}
