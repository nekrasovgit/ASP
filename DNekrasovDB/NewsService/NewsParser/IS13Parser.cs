﻿using DNekrasovDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.NewsService.NewsParser
{
    public interface IS13Parser
    {
        public News Parse(string rssurl);
    }
}
