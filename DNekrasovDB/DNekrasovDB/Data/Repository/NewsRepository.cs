using DNekrasovDB.Models.DB;

namespace DNekrasovDB.Data.Repository
{
    public class NewsRepository : Repository<News>
    {
        public NewsRepository(GoodNewsContext goodNewsContext) : base(goodNewsContext)
        {
        }
    }
}
