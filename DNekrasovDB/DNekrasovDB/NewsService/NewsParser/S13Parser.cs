
using DNekrasovDB.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.NewsService.NewsParser
{
    public class S13Parser : IS13Parser
    {

 

        

        public News Parse(string rssurl)
        {
            var web = new HtmlWeb();
            var doc = web.Load(rssurl);
            var docNode = doc.DocumentNode;

            var listS13 = doc.DocumentNode.Descendants("div").
               Where(x => x?.Attributes["class"]?.Value == "content").ToList();

            var body = listS13.FirstOrDefault()?.InnerHtml;


            return new News()
            {
                Id = Guid.NewGuid(),
                Body = body
            };




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


            
        }
    }
}
