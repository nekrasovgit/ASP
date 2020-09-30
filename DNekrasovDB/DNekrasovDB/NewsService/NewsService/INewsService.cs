using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;
using DNekrasovDB.Models.DB;
using System.Threading.Tasks;

namespace DNekrasovDB.Data.NewsService
{
    public interface INewsService
    {
        public Task InsertNewsFromRssToDb();

        
    }
}
