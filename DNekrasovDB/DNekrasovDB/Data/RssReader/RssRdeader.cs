using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace DNekrasovDB.Data.RssReader
{
    public class RssReader : IRssReader
    {
        private readonly ILogger _logger;

        public RssReader(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<SyndicationItem> GetNewsFromFeed(string feedurl)
        {
            try
            {


                using (var reader = XmlReader.Create(feedurl))
                {
                    var feed = SyndicationFeed.Load(reader);

                    foreach (var item in feed.Items)
                    {
                        item.SourceFeed = feed;
                    }

                    var mynews = feed.Items.ToArray();
                    return mynews;
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }


}