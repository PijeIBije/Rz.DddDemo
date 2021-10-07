using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;
using Rz.DddDemo.Base.Infrastructure.EntityFramework;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Reservations.Application.Interfaces;
using Rz.DddDemo.Reservations.Domain.Customer;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql;
using Rz.DddDemo.Reservations.Infrastructure.Schemas.Database.Sql.Dtos;

namespace Rz.DddDemo.Reservations.Infrastructure.CustomerRepository.EfCoreSql
{
    public class CustomerRepository:EfRepositoryBase<ReservationsDbContext>, ICustomerRepository
    {
        private readonly IMapper mapper;

        public CustomerRepository(
            IMapper mapper,
            IDbContextFactory<ReservationsDbContext> dbContextFactory, 
            ITransactionEvents transactionEvents) : base(dbContextFactory, transactionEvents)
        {
            this.mapper = mapper;
        }

        public async Task<CustomerAggregate> GetById(CustomerId customerId)
        {
            var customerDto = await DbContext.Customers.SingleOrDefaultAsync(x=>x.Id == customerId);

            var cusomter = mapper.Map<CustomerDto,CustomerAggregate>(customerDto);

            return cusomter;
        }

        public Task Save(CustomerAggregate customerAggregate)
        {
            var customerDto = mapper.Map<CustomerAggregate, CustomerDto>(customerAggregate);

            DbContext.Customers.Update(customerDto);

            return Task.CompletedTask;
        }
    }
}
