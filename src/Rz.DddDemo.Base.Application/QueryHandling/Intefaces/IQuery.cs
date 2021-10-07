using System;
using MediatR;

namespace Rz.DddDemo.Base.Application.QueryHandling.Intefaces
{
    public interface IQuery<TResult>:IRequest<TResult>
    {
    }
}
