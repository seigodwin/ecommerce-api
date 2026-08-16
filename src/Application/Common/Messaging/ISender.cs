using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Messaging
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
