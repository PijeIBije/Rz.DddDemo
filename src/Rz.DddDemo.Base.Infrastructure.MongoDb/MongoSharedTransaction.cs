using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.MongoDb
{
    public class MongoSharedTransaction
    {
        private readonly MongoClient mongoClient;

        private readonly List<Task> mongoTransactionTasks = new List<Task>();

        public delegate void Commit(List<Task> transactionTasks);

        public event Commit CommitEvent;

        public MongoSharedTransaction(MongoClient mongoClient,ITransactionEvents transactionEvents)
        {
            this.mongoClient = mongoClient;
            transactionEvents.CommitEvent += TransactionEventsCommitEvent;
        }

        private void TransactionEventsCommitEvent(List<Task> transactionTasks)
        {
            transactionTasks.Add(Task.Run(async () =>
            {
                using var session = await mongoClient.StartSessionAsync();
                session.StartTransaction();
                CommitEvent?.Invoke(mongoTransactionTasks);
                foreach (var mongoTransactionTask in mongoTransactionTasks)
                {
                    await mongoTransactionTask;
                }
                mongoTransactionTasks.Clear();
                await session.CommitTransactionAsync();
            }));
        }
    }
}
