using System.Threading.Tasks;
using MediatR;

namespace Rz.DddDemo.Base.Application.QueryHandling.Intefaces
{
    public interface IQueryHandler<in TQuery,TResult>:IRequestHandler<TQuery,TResult> where TQuery:IQuery<TResult>
    {
    }
}
