using DNekrasovDB.Models.DB;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsParser
{
    public class OnlinerParser : INewsParser
    {
        public IEnumerable<News> Parse(string rssurl)
        {
            var url = "https://www.onliner.by";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var docNode = doc.DocumentNode;

            var news = new List<News>();

            var title = doc.DocumentNode.Descendants("div").
               FirstOrDefault(x => x?.Attributes["class"]?.Value == "news-header__title").Descendants("h1").ToString();


            var body = doc.DocumentNode.Descendants("div").
               Where(x => x?.Attributes["class"]?.Value == "news-text").ToString();
            
            news.Add(new News()
            {
                Name = title,
                Body = body,
            });


            return news;

            /*< a href = "https://ads.adfox.ru/239538/goLink?ad-session-id=1064061599751361443&amp;puid28=epam%3Ait-belarus%3Aonliner%3Awargaming%3Apvt&amp;puid26=tech&amp;hash=3b5561d561558459&amp;sj=gPiEDtx2yGoBCfto1asb3yumJ7mCh5cq6qvZ66FH8z333qWismQsgtwC5PmVXLBScnBusqieQ9SxmamZdkb98l1vRJxhjHfD_QHgn4Ut5A%3D%3D&amp;rand=fcangr&amp;rqs=Tea907XUhTzARFpfHBIg52KqIEZvsHhr&amp;pr=bmcdavn&amp;p1=cdale&amp;ytt=448257155663893&amp;p5=ijwap&amp;ybv=0.1839&amp;p2=fgou&amp;ylv=0.1840&amp;pf=https%3A%2F%2Fstr.by%2Fall-news%2Fnovyj-uchebnyj-god%3Futm_source%3Donliner.by%26utm_medium%3Dbanner%26utm_campaign%3Daugust24.08" target = "_blank" >< img src = "https://banners.adfox.ru/200821/adfox/1418269/3828879.315a993d94f1f41e17a0214a7449d5f4.png" style = "width: 100%; height: auto; border: 0px; vertical-align: middle; max-width: 300px;" ></ a >*/
            /*< a href = "https://www.facebook.com/sharer.php?u=https%3A%2F%2Ftech.onliner.by%2F2020%2F09%2F10%2Fbolshoj-isxod-ajtishnikov-ili-vremennyj-relokejt-chto-teper-budet-s-it-stranoj" target = "_blank" class="button-style button-style_extra button-style_small news-reference__button news-reference__button_fb" title="Поделиться в Facebook"></a>*/
            /*< a href = "https://vk.com/share.php?url=https%3A%2F%2Ftech.onliner.by%2F2020%2F09%2F10%2Fbolshoj-isxod-ajtishnikov-ili-vremennyj-relokejt-chto-teper-budet-s-it-stranoj" target = "_blank" class="button-style button-style_accessorial button-style_small news-reference__button news-reference__button_vk" title="Поделиться в VK"></a>*/
            /*< a href = "https://twitter.com/intent/tweet?url=https%3A%2F%2Ftech.onliner.by%2F2020%2F09%2F10%2Fbolshoj-isxod-ajtishnikov-ili-vremennyj-relokejt-chto-teper-budet-s-it-stranoj&amp;text=«Большой исход айтишников» или временный релокейт? Что теперь будет с IT-страной" target = "_blank" class="button-style button-style_appendant button-style_small news-reference__button news-reference__button_tw" title="Поделиться в Twitter"></a>*/
            /*< a href = "https://connect.ok.ru/offer?url=https%3A%2F%2Ftech.onliner.by%2F2020%2F09%2F10%2Fbolshoj-isxod-ajtishnikov-ili-vremennyj-relokejt-chto-teper-budet-s-it-stranoj" target = "_blank" class="button-style button-style_supererogatory button-style_small news-reference__button news-reference__button_ok" title="Поделиться в OK"></a>*/
            /*< a href = "viber://forward?text=https%3A%2F%2Ftech.onliner.by%2F2020%2F09%2F10%2Fbolshoj-isxod-ajtishnikov-ili-vremennyj-relokejt-chto-teper-budet-s-it-stranoj" target = "_blank" class="button-style button-style_supernumerary button-style_small news-reference__button news-reference__button_vb" title="Поделиться в Viber"></a>*/
            /*< a href = "https://t.me/share/url?url=https%3A%2F%2Ftech.onliner.by%2F2020%2F09%2F10%2Fbolshoj-isxod-ajtishnikov-ili-vremennyj-relokejt-chto-teper-budet-s-it-stranoj" target = "_blank" class="button-style button-style_additional button-style_small news-reference__button news-reference__button_tg" title="Поделиться в Telegram"></a>*
            /*< a href = "https://tech.onliner.by/2020/08/21/ya-ponimayu-chto-mogu-poteryat-vse-razrabotchik-golosa-vyshel-iz-teni-im-okazalsya-top-menedzher-it-kompanii/" > говорил </ a >*/
            /*< img loading = "lazy" class="aligncenter" src="https://content.onliner.by/news/1100x5616/95ec9f6cf147f3340ebe9203e1945456.jpeg" alt="">*/
            /*< a href = "https://vc.ru/finance/147991-startap-pandadoc-s-osnovatelyami-iz-belorussii-privlek-30-mln-ot-fonda-microsoft-one-peak-partners-i-drugih" target = "_blank" > стало известно </ a >*/
            /*< img loading = "lazy" class="aligncenter" src="https://content.onliner.by/news/1100x5616/7b71173ff24653a213c39fdb69fa1ae3.jpeg" alt="">*/
            /*< a href = "https://auto.onliner.by/2020/08/13/v-minskix-ofisax-yandeks-taksi-i-uber-obyski/" > произошли </ a >*/
            /*< img loading = "lazy" class="aligncenter" src="https://content.onliner.by/news/1100x5616/d4818fda24ff7c634ab1ea1a0e986641.jpeg" alt="">*/
            /*< a href = "https://tech.onliner.by/2020/08/18/perelomy-povrezhdeniya-vnutrennix-organov-gematomy-glava-iba-group-o-sostoyanii-osvobozhdennyx-sotrudnikov/" > рассказал </ a >*/
            /*< img loading = "lazy" class="aligncenter" src="https://content.onliner.by/news/1100x5616/4e825e8485f6cdbb71dfdff0f68c8a95.jpeg" alt="">*/
        }
    }
}
