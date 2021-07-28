using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.EntityFramework
{
    public class RepositoryBase<TDbContext> where TDbContext:DbContext
    {
        private readonly TDbContext dbContext;

        public RepositoryBase(TDbContext dbContext, ITransactionEvents transactionEvents)
        {
            this.dbContext = dbContext;
            transactionEvents.CommitEvent += TransactionEventsCommitEvent;
        }

        private void TransactionEventsCommitEvent(List<Func<Task>> transactionTasks)
        {
            if(dbContext.ChangeTracker.HasChanges())
                transactionTasks.Add(async ()=> await dbContext.SaveChangesAsync());
        }
    }
}
