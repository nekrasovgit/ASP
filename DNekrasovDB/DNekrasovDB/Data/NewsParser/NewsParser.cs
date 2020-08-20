
using System.Linq;
using HtmlAgilityPack;

namespace DNekrasovDB.Data.NewsParser
{
    class NewsParser : INewsParser
    {
        public void Parse(string rssurl)
        {
            var url = "http://html-agility-pack.net/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var docNode = doc.DocumentNode;

            var title = doc.DocumentNode.Descendants("h1").
               FirstOrDefault(x => x?.Attributes["itemprop"]?.Value == "headline");
        
        
            var body = doc.DocumentNode.Descendants("div").
               Where(x => x?.Attributes["id"]?.Value == "article_body").ToList();

        }
        
    }
}
