namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class CustomerIncludes
    {
        public bool Name { get; set; }

        public bool PhoneNumber { get; set; }

        public bool EmailAddress { get; set; }
        public PurchaseIncludes PurchaseIncludes { get; set; }
    }
}
