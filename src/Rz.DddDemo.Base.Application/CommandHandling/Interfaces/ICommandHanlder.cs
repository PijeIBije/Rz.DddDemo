using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Application.CommandHandling.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand:ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
