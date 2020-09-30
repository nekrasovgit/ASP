using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.Queries.NewsQueries
{
    class GetNewsByIdQuery : IRequest<News>
    {
        public Guid Id { get; }

        public GetNewsByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
