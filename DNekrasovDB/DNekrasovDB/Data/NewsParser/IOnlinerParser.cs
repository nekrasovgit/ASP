﻿using DNekrasovDB.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsParser
{
    public interface IOnlinerParser
    {
        public News Parse(string rssurl);
    }
}
