using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Orders.Application.Interfaces;
using Rz.DddDemo.Orders.Domain.Order;
using Rz.DddDemo.Orders.Domain.Order.ValueObjects;

namespace Rz.DddDemo.Orders.Application.Commands.Order
{
    public class CreateOrderCommandHandler:CommandHandlerBase<CreateOrderCommand,OrderId>
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;

        public CreateOrderCommandHandler(
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher, 
            Transaction transaction,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository) : base(
            domainEventsHandler, 
            integrationEventsPublisher, 
            transaction)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
        }

        protected override async Task<OrderId> HandleBody(CreateOrderCommand command)
        {
            var orderLines = new List<OrderLineEntity>();

            var products = (await productRepository.GetByIds(command.OrderLines.Select(x => x.ProductId))).ToList();

            foreach (var orderLineData in command.OrderLines)
            {
                var product = products.Single(x => x.Id == orderLineData.ProductId);
                var orderLine = new OrderLineEntity(orderLineData.ProductId,product.Price,orderLineData.Quantity);
                orderLines.Add(orderLine);
            }

            var customer = await customerRepository.GetById(command.CustomerId);

            var address = customer.Addresses.SingleOrDefault(x => x.Name == command.AddressName);

            var shippingAddress = new ShippingAddress(customer.FirstName,customer.LastName,address);

            var order = new OrderAggregate(shippingAddress,orderLines);

            await orderRepository.Save(order);

            return order.Id;
        }
    }
}
