using System.Threading.Tasks;
using Rz.DddDemo.Orders.Domain.AutoCancellationParameters;

namespace Rz.DddDemo.Orders.Application.Interfaces
{
    public interface IAutoCancellationParametersRepository
    {
        public Task<AutoCancellationParametersAggregate> Get();
            
        public Task Save(AutoCancellationParametersAggregate autoCancellationParameters);
    }
}