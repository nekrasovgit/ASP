using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace DNekrasovDB.Data.RssReader
{
    public interface IRssReader
    {
        public IEnumerable<SyndicationItem> GetNewsFromFeed(string feedurl);
        // GetNewsFromFeed - rename to GetNewsDataFromFeed
        
    }
}
