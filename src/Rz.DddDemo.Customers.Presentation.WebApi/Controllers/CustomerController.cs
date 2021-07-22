using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.Commands.Customer;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model;
using Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;
using Rz.DddDemo.Customers.Domain.ValueObjects;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : DddDemo.Base.Presentation.WebApi.ControllerBase
    {
        private readonly IQueryHandler<CustomerQuery,IEnumerable<CustomerResult>> customerQueryHandler;
        private readonly ICommandHandler<CreateCustomerCommand, CustomerId> createCustomerCommandHandler;
        private readonly ICommandHandler<UpdateCustomerCommand> updateCustomerCommandHandler;
        private readonly IMapper mapper;
        private readonly IncludesMapper includesMapper;

        public CustomerController(
            IQueryHandler<CustomerQuery,IEnumerable<CustomerResult>> customerQueryHandler, 
            ICommandHandler<CreateCustomerCommand, CustomerId> createCustomerCommandHandler, 
            ICommandHandler<UpdateCustomerCommand> updateCustomerCommandHandler,
            IMapper mapper, 
            IncludesMapper includesMapper,
            IExceptionMapper exceptionMapper,
            HttpContextAccessor httpContextAccessor
            ):base(httpContextAccessor,exceptionMapper)
        {
            this.customerQueryHandler = customerQueryHandler;
            this.createCustomerCommandHandler = createCustomerCommandHandler;
            this.updateCustomerCommandHandler = updateCustomerCommandHandler;
            this.mapper = mapper;
            this.includesMapper = includesMapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerResource),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid id, List<string> includes)
        {
            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerId = id,
                CustomerIncludes = includesObject
            };

            var results = await customerQueryHandler.Handle(query);

            return Ok(mapper.Map<CustomerResult,CustomerResult>(results.Single()));
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerResource), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(List<string> includes)
        {
            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerIncludes = includesObject
            };

            var results = await customerQueryHandler.Handle(query);

            return Ok(results.Select(x=>mapper.Map<CustomerResult,CustomerResource>(x)));
        }

        public async Task<IActionResult> Post([FromBody] CustomerResource customerResource, List<string> includes)
        {
            var command = new CreateCustomerCommand
            {
                CustomerId = customerResource.Id,
                DateOfBirth = customerResource.DateOfBirth,
                LastName = customerResource.LastName,
                FirstName = customerResource.FirstName,
                Addresses = customerResource.Addresses.Select(x=>mapper.Map<AddressResource,AddressUpdate>(x)).ToList()
            };

            var customerId = await createCustomerCommandHandler.Handle(command);

            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerId = customerId,
                CustomerIncludes = includesObject
            };

            var results = await customerQueryHandler.Handle(query);

            return Ok(mapper.Map<CustomerResult, CustomerResult>(results.Single()));
        }

        public async Task<IActionResult> Patch([FromQuery]Guid customerId, [FromBody] CustomerPatch customerPatch, List<string> includes)
        {
            var command = new UpdateCustomerCommand()
            {
                CustomerId = customerId,
                DateOfBirth = customerPatch.DateOfBirth,
                LastName = customerPatch.LastName,
                FirstName = customerPatch.FirstName,
                AddressesToAddOrUpdate = customerPatch.AddressesToAddOrUpdate.Select(x => mapper.Map<AddressResource, AddressUpdate>(x)).ToList(),
                AddresesToRemoveNames = customerPatch.AddressesToRemove.Select(x=>new AddressName(x)).ToList()
            };

            await updateCustomerCommandHandler.Handle(command);

            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerId = customerId,
                CustomerIncludes = includesObject
            };

            var results = await customerQueryHandler.Handle(query);

            return Ok(mapper.Map<CustomerResult, CustomerResult>(results.Single()));
        }
    }
}
