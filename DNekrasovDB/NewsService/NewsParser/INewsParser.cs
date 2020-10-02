using DNekrasovDB.Models;


namespace DNekrasovDB.NewsService.NewsParser
{
    public interface INewsParser
    {
        public News Parse(string rssurl);
    }
}
