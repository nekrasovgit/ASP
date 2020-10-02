
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsService
{
    public interface INewsService
    {
        public Task InsertNewsFromRssToDb();

        
    }
}
