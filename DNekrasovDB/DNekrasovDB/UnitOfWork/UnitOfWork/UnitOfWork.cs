
using System.Threading.Tasks;
using DNekrasovDB.Models;
using DNekrasovDB.UnitOfWork.Repository;

namespace DNekrasovDB.UnitOfWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GoodNewsContext _goodNewsContext;

        public IRepository<News> NewsRepository { get; }

        public IRepository<Magazine> MagazineRepository { get; }

        public UnitOfWork(GoodNewsContext goodNewsContext,
            IRepository<News> newsRepository,
            IRepository<Magazine> magazineRepository)
        {
            _goodNewsContext = goodNewsContext;
            NewsRepository = newsRepository;
            MagazineRepository = magazineRepository;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _goodNewsContext.SaveChangesAsync();
        }

    }
}
