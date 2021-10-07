using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.Dapper
{
    public class SqlTransactionWrapper
    {
        public delegate void Commit(IDbTransaction transaction);

        private readonly string connectionString;

        public SqlTransactionWrapper(ITransactionEvents transactionEvents, string connectionString)
        {
            this.connectionString = connectionString;
            transactionEvents.CommitEvent += TransactionEventsCommitEvent;
        }

        private void TransactionEventsCommitEvent(List<Func<Task>> transactiontasks)
        {
            async Task Task()
            {
                var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                var sqlTransaction = await sqlConnection.BeginTransactionAsync();
                CommitEvent?.Invoke(sqlTransaction);
                await sqlTransaction.CommitAsync();
            }

            transactiontasks.Add(Task);
        }

        public event Commit CommitEvent;
    }
}
