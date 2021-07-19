using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using NUnit.Framework;
using Rz.DddDemo.Base.Application;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Base.Mapping;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.DomainObjects;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.Commands.Customer;
using Rz.DddDemo.Customers.Infrastructure.CustomerRepository.Mock;
using Rz.DddDemo.Base.Infrastructure;

namespace Rz.DddDemo.Customers.Tests.Integration.Commands.Customer
{
    [TestFixture]
    public class CustomerCommandsTests
    {
        private CreateCustomerCommandHandler createCustomerCommandHandler= null;
        private UpdateCustomerCommandHandler updateCustomerCommandHandler=null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //var connectionString = @"mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false";

            var entityCache = new EntityCache();

            var valueMappings = new IValueMapping[]
            {
                new ObjectToSingleValueObject(),
                new SingleValueToObjectMapping(),
                new DictionaryMapping(),
                new ListMapping(),
                new ClassMapping(),
                new ValueTypeMapping(),
            };

            var mapper = new Mapper(valueMappings);

            var customerRepository = new CustomerRepository(entityCache,mapper);

            var transaction = new Transaction();
            var domainEventsHandler =
                new DomainEventsHandler(type => throw new NotImplementedException());
            var integrationEventsPublisher = new IntegrationEventsPublisher(type => throw new NotImplementedException());

            createCustomerCommandHandler = new CreateCustomerCommandHandler(
                customerRepository, domainEventsHandler, integrationEventsPublisher, transaction);
            updateCustomerCommandHandler = new UpdateCustomerCommandHandler(customerRepository, domainEventsHandler, integrationEventsPublisher, transaction);
        }


    }
}
