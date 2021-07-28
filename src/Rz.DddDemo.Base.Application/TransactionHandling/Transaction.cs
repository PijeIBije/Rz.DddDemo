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

        private readonly List<Func<Task>> transactionTasks = new List<Func<Task>>();

        public async Task Commit()
        {
            if(!Started) throw new InvalidOperationException($"{nameof(Transaction)} is not started");

            CommitEvent?.Invoke(transactionTasks);

            foreach (var transactionTask in transactionTasks)
            {
                await transactionTask();
            }

            transactionTasks.Clear();
            Started = false;
            CommitedEvent?.Invoke(transactionTasks);

            foreach (var transactionTask in transactionTasks)
            {
                await transactionTask();
            }

            transactionTasks.Clear();
        }
    }
}
