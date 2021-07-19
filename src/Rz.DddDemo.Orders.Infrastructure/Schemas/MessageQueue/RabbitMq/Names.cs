namespace Rz.DddDemo.Orders.Infrastructure.Schemas.MessageQueue.RabbitMq
{
    public static class Names
    {
        public static class Customer
        {
            public const string ExchangeName = "Customers";

            public const string QueueName = "Orders";

            public static class Topics
            {
                public const string CustomerCreated = "Customer.Created";

                public const string CustomerUpdated = "Customer.Updated";
            }
        }
    }
}
