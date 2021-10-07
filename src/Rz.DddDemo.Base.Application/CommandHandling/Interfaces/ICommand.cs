using MediatR;

namespace Rz.DddDemo.Base.Application.CommandHandling.Interfaces
{
    public interface ICommand<TResult>:IRequest<TResult>
    {
    }
}
