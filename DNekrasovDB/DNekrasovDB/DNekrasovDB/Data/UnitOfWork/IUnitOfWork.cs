using DNekrasovDB.Models.DB;
using System.Threading.Tasks;
using DNekrasovDB.Data.Repository;
using System.Collections.Generic;

namespace DNekrasovDB.Data.UnitOfWork
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
