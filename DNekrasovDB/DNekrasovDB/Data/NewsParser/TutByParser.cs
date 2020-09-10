using DNekrasovDB.Models.DB;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsParser
{
    public class TutByParser : INewsParser
    {
        

        public IEnumerable<News> Parse(string rssurl)
        {
            var url = "https://www.tut.by/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var news = new List<News>();

            var docNode = doc.DocumentNode;

            var title = doc.DocumentNode.Descendants("h1").
               FirstOrDefault(x => x?.Attributes["itemprop"]?.Value == "headline").InnerText;


            var body = doc.DocumentNode.Descendants("div").
               Where(x => x?.Attributes["id"]?.Value == "article_body").ToList().ToString();
            news.Add(new News()
            {
                Name = title,
                Body = body,
            });

            return news;

            /*w = < a href = "http://president.gov.by/ru/news_ru/view/aleksandr-lukashenko-predstavil-andreja-shveda-v-dolzhnosti-generalnogo-prokurora-24499/" target = "_blank" > сообщает </ a >*/

            /*< figure class="image-captioned" style="width: 100%; max-width: 555px;" data-resized="1"><img alt = "Фото: president.gov.by" border="0" data-zoom="1" hspace="0" loading="lazy" src="https://dh.img.tyt.by/n/prezident/0c/8/000374_211947.jpg" title="Фото: president.gov.by" vspace="0" width="665" data-resized="1" style="width: 100%; max-width: 555px; cursor: pointer;">
            <figcaption>Фото: president.gov.by</figcaption>
            </figure>*/
            /*< a href = "https://news.tut.by/economics/699842.html" target = "_blank" title = "Лукашенко назначил нового генпрокурора. У&nbsp;Конюка «есть желание поработать на&nbsp;дипломатической службе»" > назначил </ a >*/
        }
    }
}
