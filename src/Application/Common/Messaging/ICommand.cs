using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Messaging
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }

    //For commands that do not return a response, you can use the Unit type as the response type.
    public interface ICommand : ICommand<Unit>
    {
    }
}
