﻿using System;
using System.Collections.Generic;
using System.Linq;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound;
using Rz.DddDemo.Orders.Presentation.WebApi.RabbitMqMessageHandlers.Dto;
using Rz.DddDemo.Base.Presentation.WebApi.RabbitMqHostedService;
using Rz.DddDemo.Orders.Domain.Customer.Address;

namespace Rz.DddDemo.Orders.Presentation.WebApi.RabbitMqMessageHandlers
{
    public class CustomerCreatedMessageHandlerBase:MessageHandlerBase<CustomerCreatedDto,CustomerCreatedIntegrationEvent>
    {
        public CustomerCreatedMessageHandlerBase(
            string exchangeName, 
            string routingKey, 
            Dictionary<string, object> arguments, Func<Type, IIntegrationEventHandler> integrationEventHandlerLocator) : base(exchangeName, routingKey, arguments, integrationEventHandlerLocator)
        {
        }

        public override CustomerCreatedIntegrationEvent ToIntegrationEvent(CustomerCreatedDto messageDto)
        {
            return new CustomerCreatedIntegrationEvent
            {
                LastName = messageDto.LastName,
                FirstName = messageDto.FirstName,
                CustomerId = messageDto.CustomerId,
                Addresses = messageDto.AddressDtos.Select(x => new AddressValueObject(
                    x.Name,
                    x.AddressLine1,
                    x.AddressLine2,
                    x.City,
                    x.PhoneNumber,
                    x.EmailAddress,
                    x.Country)).ToList()
            };
        }
    }
}
