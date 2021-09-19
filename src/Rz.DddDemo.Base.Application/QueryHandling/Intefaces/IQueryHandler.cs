﻿using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Application.QueryHandling.Intefaces
{
    public interface IQueryHandler<in TQuery,TResult> where TQuery:IQuery<TResult>
    {
        public Task<TResult> Handle(TQuery query);
    }
}
