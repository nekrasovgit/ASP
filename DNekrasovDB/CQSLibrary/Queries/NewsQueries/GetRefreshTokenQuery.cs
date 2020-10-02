using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.Queries.NewsQueries
{
    public class GetRefreshTokenQuery : IRequest<RefreshToken>
    {
        public string Token { get; }

        public GetRefreshTokenQuery(string token)
        {
            Token = token;
        }
    }
}
