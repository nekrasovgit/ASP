using CQSLibrary.Commands.NewsCommands;
using DNekrasovDB.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQSLibrary.CommandHandlers
{
    public class AddRangeNewsHandler : IRequestHandler<AddRangeNews, Guid[]>
    {
        private readonly GoodNewsContext _goodNewsContext;

        public AddRangeNewsHandler(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }
        public async Task<Guid[]> Handle(AddRangeNews request, CancellationToken cancellationToken)
        {
            await _goodNewsContext.News.AddRangeAsync(request.News, cancellationToken);
            await _goodNewsContext.SaveChangesAsync(cancellationToken);

            return request.News.Select(s => s.Id).ToArray();
        }
    }
}
