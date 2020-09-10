using DNekrasovDB.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsParser
{
    public interface INewsParser
    {
        public IEnumerable<News> Parse(string rssurl);
    }
}
