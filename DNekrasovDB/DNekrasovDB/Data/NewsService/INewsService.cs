using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;

namespace DNekrasovDB.Data.NewsService
{
    public interface INewsService
    {
        public void GetDataFromRssInsertIntoDB();

        
    }
}
