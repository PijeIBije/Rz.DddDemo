namespace Rz.DddDemo.Shipping.Infrastructure.Schemas.Database.Sql
{
    public static class Schema
    {
        public const string SchmeaName = "dbo";

        public const string DbName = "Repertory";

        public static class Tables
        {
            public static class Orders
            {
                public const string Name = nameof(Orders);

                public static class Columns
                {
                    public const string Id = nameof(Id);

                    public const string OrderLines = nameof(OrderLines);

                    public const string Address = nameof(Address);
                }
            }

            public static class Shipments
            {
                public const string Name = nameof(Shipments);

                public static class Columns
                {
                    public const string Id = nameof(Id);

                    public const string IsShipped = nameof(IsShipped);

                    public const string OrderIds = nameof(OrderIds);

                    public const string PurchaseHistory = nameof(PurchaseHistory);
                }
            }
        }
    }
}
