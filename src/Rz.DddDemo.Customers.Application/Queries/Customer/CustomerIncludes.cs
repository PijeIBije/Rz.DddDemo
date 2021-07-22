namespace Rz.DddDemo.Customers.Application.Queries.Customer
{
    public class CustomerIncludes
    {
        public bool FirstName { get; set; }

        public bool LastName { get; set; }

        public bool DateOfBirth { get; set; }
        public AddressIncludes Addresses { get; set; }
    }
}
