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
    class GetNewsByIdHandler  : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public GetNewsByIdHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _goodNewsContext.News.FirstOrDefaultAsync(s => s.Id.Equals(request.Id), cancellationToken);

            return result;
        }
    }
}
