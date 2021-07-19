using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Application.QueryHandling.Intefaces
{
    public interface IQueryHandler<in TQuery,TResult> where TQuery:IQuery
    {
        public Task<TResult> Handle(TQuery query);
    }
}
