namespace Rz.DddDemo.Customers.Infrastructure.Schemas.MessageQueue.RabbitMq
{
    public class Names
    {
        public const string CustomerExchangeName = "Customer";

        public static class Topics
        {
            public const string CustomerCreated = "Customer.Created";

            public const string CustomerUpdated = "Customer.Updated";
        }
    }
}
