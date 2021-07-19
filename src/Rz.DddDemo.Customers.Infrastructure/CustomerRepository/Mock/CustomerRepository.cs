using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.Commands.Interfaces;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.CustomerAggregate;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate;
using Rz.DddDemo.Customers.Domain.CustomerAggregate.ValueObjects;
using Rz.DddDemo.Base.Infrastructure;

namespace Rz.DddDemo.Customers.Infrastructure.CustomerRepository.Mock
{
    public class CustomerRepository:
        ICustomerRepository,
        Application.Queries.Interfaces.ICustomerRepository

    {
        private readonly EntityCache entityCache;
        private readonly IMapper mapper;

        public CustomerRepository(EntityCache entityCache,IMapper mapper)
        {
            this.entityCache = entityCache;
            this.mapper = mapper;
        }

        public Task<Customer> GetById(CustomerId customerId)
        {
            return Task.FromResult(entityCache.GetExisting<Customer,CustomerId>(customerId));
        }

        public Task Save(Customer customerEntity)
        {
            entityCache.AddToSave(customerEntity.Id,customerEntity);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<CustomerResult>> Get(CustomerId customerId, CustomerIncludes customerIncludes)
        {
            if (customerId != null)
            {
                var entity = entityCache.GetExisting<Customer, CustomerId>(customerId);

                IEnumerable<CustomerResult> result = new CustomerResult[] {mapper.Map<Customer,CustomerResult>(entity)};

                return Task.FromResult(result);
            }
            else
            {
                var entities = entityCache.GetExisting<Customer>();

                return Task.FromResult(entities.Select(x=>mapper.Map<Customer,CustomerResult>(x)));
            }
        }
    }
}
