namespace Rz.DddDemo.Orders.Infrastructure.Schemas.MessageQueue.RabbitMq
{
    public static class Names
    {
        public const string QueueName = "Orders";

        public static class Customer
        {
            public const string ExchangeName = "Customers";

            public static class Topics
            {
                public const string CustomerUpdated = "Customer.Updated";
            }
        }

        public static class Orders
        {
            public const string ExchangeName = "Orders";

            public static class Topics
            {
                public const string OrderPaid = "Order.Paid";

                public const string OrderUpdated = "Order.Updated";
            }
        }
    }
}
