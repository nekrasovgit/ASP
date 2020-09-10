using DNekrasovDB.Data.UnitOfWork;
using DNekrasovDB.Models.DB;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsParser
{
    public class S13Parser : INewsParser
    {
        private readonly IUnitOfWork _unitOfWork;

        private const string url_S13 = @"http://s13.ru";

        public S13Parser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        public IEnumerable<News> Parse(string rssurl)
        {
            
            var web = new HtmlWeb();
            var doc = web.Load(url_S13);

            var docNode = doc.DocumentNode;

            var news = new List<News>();

            var title = doc.DocumentNode.Descendants("div").
               FirstOrDefault(x => x?.Attributes["class"]?.Value == "content").Descendants("h1").ToString();


            var body = doc.DocumentNode.Descendants("div").
               Where(x => x?.Attributes["class"]?.Value == "content").ToList().ToString();

            

            var x = "<h1> Hello World</h1>";

            x = x.Remove(0, 4);

            //string e = "<span title="Просмотров">5666</span>";
            //e = e.Remove(0, 4);

            //string e = "<a href="#comments" title="Комментарии" rel="nofollow">2</a>";
            //e = e.Remove(0, 1);

            //string e = "<span>08 сентября 2020, 16:40</span>";
            //e = e.Remove(0, 21);

            //string e = "<a href="/archives/arhive/?tags=суд" class="tag">суд</a>";
            //e = e.Remove(0, 3);

            //string e = "<a href="/archives/arhive/?tags=Гродно" class="tag">Гродно</a>";
            //e = e.Remove(0, 6);

            //string e = "<a href="/archives/arhive/?tags=аварии" class="tag">аварии</a>";
            //e = e.Remove(0, 6);

            //string e = "<a href="https://www.belta.by/incident/view/razognalsja-do-136-kmch-sud-vynes-prigovor-po-delu-o-pjjanom-dtp-v-grodno-405956-2020/">БЕЛТА</a>";
            //e = e.Remove(0, 5);

            //string e = "<<a href="http://s13.ru/archives/dtp-162">Резонансное ДТП произошло в марте</a>";
            //e = e.Remove(0, 33);

            //string e = "<img src="http://s13.ru/ru/files/megacat/image/720/0/1583226670.jpg">";
            //e = e.Remove(0, 33);

            //string e = "<img alt="" src="http://s13.ru/ru/files/megacat/image/720/0/1583226669.jpg">";
            //e = e.Remove(0, 33);

            //string e = "<img alt="" src="http://s13.ru/ru/files/megacat/image/720/0/1583226670_1.jpg">";
            //e = e.Remove(0, 33);


            news.Add(new News()
            {
                Name = title,
                Body = body,
            });

            return news;
        }
    }
}
