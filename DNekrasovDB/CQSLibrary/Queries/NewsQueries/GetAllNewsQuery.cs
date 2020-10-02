using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.Queries.NewsQueries
{
    public class GetAllNewsQuery : IRequest<IEnumerable<News>>
    {
    }
}
