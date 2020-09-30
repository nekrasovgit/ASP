

using DNekrasovDB.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace DNekrasovDB.Data.Storage
{
    public class Storage
    {
        private readonly GoodNewsContext _goodNewsContext;

        public Storage(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;

        }


        public static string[] rssFeeds = {
            @"https://news.tut.by/rss/all.rss",
        @"http://s13.ru/rss",
        @"https://tech.onliner.by/feed",
        };

        //public static List<News> News { get; set; }




    }
}