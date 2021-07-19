using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Application.TransactionHandling
{
    public class Transaction:ITransactionEvents
    {
        public event TransactionEventHandlers.Commit CommitEvent;
        public event TransactionEventHandlers.Commited CommitedEvent;

        public bool Started { get; private set; }

        public void Start()
        {
            Started = true;
        }

        private readonly List<Task> transactionTasks = new List<Task>();

        public async Task Commit()
        {
            if(!Started) throw new InvalidOperationException($"{nameof(Transaction)} is not started");

            CommitEvent?.Invoke(transactionTasks);
            await Task.WhenAll(transactionTasks);
            transactionTasks.Clear();
            Started = false;
            CommitedEvent?.Invoke(transactionTasks);
            await Task.WhenAll(transactionTasks);
            transactionTasks.Clear();
        }
    }
}
