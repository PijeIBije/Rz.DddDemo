using Rz.DddDemo.Base.Domain.DomainEntity;

namespace Rz.DddDemo.Reservations.Domain.Customer
{
    public class CustomerAggregate:DomainEntityBase<CustomerId>
    {
        public CustomerAggregate(CustomerId id) : this(id,null)
        {
        }

        public CustomerAggregate(CustomerId id, Discount currentDiscount) : base(id)
        {

        }

        public Discount CurrentDiscount { get; set; }
    }
}
