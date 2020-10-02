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
    public class AddNewsHandler : IRequestHandler<AddNews, bool>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public AddNewsHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task<bool> Handle(AddNews request, CancellationToken cancellationToken)
        {
            await _goodNewsContext.News.AddAsync(request.News, cancellationToken);
            await _goodNewsContext.SaveChangesAsync(cancellationToken);

            return true;

        }
    }
}
