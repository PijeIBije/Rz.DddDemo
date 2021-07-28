using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Application.TransactionHandling
{
    public static class TransactionEventHandlers
    {
        public delegate void Commit(List<Func<Task>> transactionTasks);

        public delegate void Commited(List<Func<Task>> transactionTasks);
    }
}
