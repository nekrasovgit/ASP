using DNekrasovDB.Models;


namespace DNekrasovDB.NewsService.NewsParser
{
    public interface IOnlinerParser
    {
        public News Parse(string rssurl);
    }
}
