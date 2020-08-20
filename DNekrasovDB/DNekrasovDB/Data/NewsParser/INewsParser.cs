using System;
using System.Collections.Generic;
using System.Text;

namespace DNekrasovDB.Data.NewsParser
{
    public interface INewsParser
    { 
        void Parse(string rssurl);
    }
}
