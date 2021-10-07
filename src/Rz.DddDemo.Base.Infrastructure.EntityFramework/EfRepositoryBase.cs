using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.EntityFramework
{
    public class EfRepositoryBase<TDbContext> where TDbContext:DbContext
    {
        protected readonly TDbContext DbContext;

        public EfRepositoryBase(IDbContextFactory<TDbContext> dbContextFactory, ITransactionEvents transactionEvents)
        {
            DbContext = dbContextFactory.CreateDbContext();
            transactionEvents.CommitEvent += TransactionEventsCommitEvent;
        }

        private void TransactionEventsCommitEvent(List<Func<Task>> transactionTasks)
        {
            if(DbContext.ChangeTracker.HasChanges())
                transactionTasks.Add(async ()=> await DbContext.SaveChangesAsync());
        }
    }
}
