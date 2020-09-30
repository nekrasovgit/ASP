using CQSLibrary.Queries.NewsQueries;
using DNekrasovDB.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQSLibrary.QueryHandlers
{
    class GetAllNewsHandler  : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public GetAllNewsHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var result = await _goodNewsContext.News.ToListAsync(cancellationToken);

            return result;
        }
    }
}
