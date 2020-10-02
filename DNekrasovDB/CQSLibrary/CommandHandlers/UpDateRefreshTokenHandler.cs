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
    public class UpDateRefreshTokenHandler : IRequestHandler<UpDateRefreshtoken, bool>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public UpDateRefreshTokenHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task<bool> Handle(UpDateRefreshtoken request, CancellationToken cancellationToken)
        {
             _goodNewsContext.RefreshTokens.UpdateRange(request.RefreshTokens, cancellationToken);
            await _goodNewsContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
