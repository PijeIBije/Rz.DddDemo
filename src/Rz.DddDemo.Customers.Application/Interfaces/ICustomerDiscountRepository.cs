using System.Threading.Tasks;
using Rz.DddDemo.Customers.Domain.CustomerDiscount;

namespace Rz.DddDemo.Customers.Application.Interfaces
{
    public interface ICustomerDiscountRepository
    {
        public Task Save(CustomerDiscountAggregate customerDiscount);
    }
}
