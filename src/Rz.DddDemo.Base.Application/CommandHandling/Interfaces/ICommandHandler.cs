using System;
using System.Threading.Tasks;
using MediatR;

namespace Rz.DddDemo.Base.Application.CommandHandling.Interfaces
{
    public interface ICommandHandler<in TCommand, TResult>: IRequestHandler<TCommand,TResult> 
        where TCommand : ICommand<TResult>
    {

    }

    public interface ICommandHandler<in TCommand> :ICommandHandler<TCommand,NoResult>
        where TCommand : ICommand<NoResult>
    {
        new Task Handle(TCommand command);
    }
}
