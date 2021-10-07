using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.Dapper
{
    public class DapperRepositoryBase
    {
        public DapperRepositoryBase(
            SqlTransactionWrapper sqlTransactionWrapper)
        {
            sqlTransactionWrapper.CommitEvent += SqlTransactionWrapperCommitEvent;
        }

        protected abstract void SqlTransactionWrapperCommitEvent(System.Data.IDbTransaction transaction)
        {
        }
    }
}
