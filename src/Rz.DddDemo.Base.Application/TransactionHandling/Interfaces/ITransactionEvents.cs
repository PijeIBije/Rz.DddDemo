namespace Rz.DddDemo.Base.Application.TransactionHandling.Interfaces
{
    public interface ITransactionEvents
    {
        public event TransactionEventHandlers.Commit CommitEvent;

        public event TransactionEventHandlers.Commited CommitedEvent;
    }
}
