using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.Commands.NewsCommands
{
    public class AddRangeNews : IRequest<Guid[]>
    {
        public IEnumerable<News> News { get; set; }

        public AddRangeNews(IEnumerable<News> news)
        {
            News = news;
        }
    }
}
