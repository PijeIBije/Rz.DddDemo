using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.MongoDb
{
    public class MongoSharedTransaction
    {
        private readonly MongoClient mongoClient;

        private readonly List<Func<Task>> mongoTransactionTasks = new List<Func<Task>>();

        public delegate void Commit(List<Func<Task>> mongoTransactionTasks);

        public event Commit CommitEvent;

        public MongoSharedTransaction(MongoClient mongoClient,ITransactionEvents transactionEvents)
        {
            this.mongoClient = mongoClient;
            transactionEvents.CommitEvent += TransactionEventsCommitEvent;
        }

        private void TransactionEventsCommitEvent(List<Func<Task>> transactionTasks)
        {
            transactionTasks.Add(async () =>
            {
                using var session = await mongoClient.StartSessionAsync();
                session.StartTransaction();
                CommitEvent?.Invoke(mongoTransactionTasks);
                foreach (var mongoTransactionTask in mongoTransactionTasks)
                {
                    await mongoTransactionTask();
                }
                mongoTransactionTasks.Clear();
                await session.CommitTransactionAsync();
            });
        }
    }
}
