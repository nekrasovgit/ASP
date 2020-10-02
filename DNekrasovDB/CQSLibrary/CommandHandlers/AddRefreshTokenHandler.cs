using CQSLibrary.Commands.NewsCommands;
using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQSLibrary.CommandHandlers
{
    public class AddRefreshTokenHandler : IRequestHandler<AddRefreshToken, bool>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public AddRefreshTokenHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task<bool> Handle(AddRefreshToken request, CancellationToken cancellationToken)
        {
            var result = await _goodNewsContext.RefreshTokens.AddAsync(request.RefreshTokens);
            var executionresult = await _goodNewsContext.SaveChangesAsync();
            return true;
        }
    }
}
