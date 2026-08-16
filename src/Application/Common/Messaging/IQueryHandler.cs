using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    {

    }
}
