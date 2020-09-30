using DNekrasovDB.Models.DB;
using System.Threading.Tasks;
using DNekrasovDB.Data.Repository;
using System.Collections.Generic;

namespace DNekrasovDB.Data.UnitOfWork
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
