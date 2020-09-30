using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace CQSLibrary.Commands.NewsCommands
{
    public class AddNews : IRequest<bool>
    {
        public News News { get; set; }

        public AddNews(News news)
        {
            News = news;
        }
    }
}
