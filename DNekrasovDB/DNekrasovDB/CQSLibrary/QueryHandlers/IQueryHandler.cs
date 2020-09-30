using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQSLibrary.QueryHandlers
{
    interface IQueryHandler<T, Q> where Q: IRequest<T>
    {
    }
}
