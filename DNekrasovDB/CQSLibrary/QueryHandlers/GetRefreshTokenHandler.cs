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
    public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenQuery, RefreshToken>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public GetRefreshTokenHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task<RefreshToken> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _goodNewsContext.RefreshTokens.AsNoTracking()
                .Include(refreshToken => refreshToken.User)
                .FirstOrDefaultAsync(refreshToken => refreshToken.Token.Equals(refreshToken));
            return result;
        }
    }
}
