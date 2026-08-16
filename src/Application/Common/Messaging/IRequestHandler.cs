using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Messaging
{
    public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }
}
