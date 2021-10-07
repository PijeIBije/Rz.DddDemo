using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.Commands.Customer;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model;
using Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping;
using Rz.DddDemo.Base.Presentation.WebApi.Validation;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : DddDemo.Base.Presentation.WebApi.ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IncludesMapper includesMapper;

        public CustomerController(
            IMediator mediator,
            IMapper mapper, 
            IncludesMapper includesMapper,
            IExceptionMapper exceptionMapper,
            IHttpContextAccessor httpContextAccessor
            ):base(httpContextAccessor,exceptionMapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.includesMapper = includesMapper;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CustomerResource),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById([ValidateAsType(typeof(CustomerId))]Guid id, [FromQuery]List<string> includes)
        {
            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerId = id,
                CustomerIncludes = includesObject
            };

            var results = await mediator.Send(query);

            return Ok(mapper.Map<CustomerResult,CustomerResult>(results.Single()));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerResource>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery]List<string> includes, CancellationToken cancellationToken)
        {
            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerIncludes = includesObject
            };

            var results = await mediator.Send(query, cancellationToken);

            return Ok(results.Select(x=>mapper.Map<CustomerResult,CustomerResource>(x)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResource), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] CustomerResource customerResource, [FromQuery]List<string> includes,CancellationToken cancellationToken)
        {
            var command = new CreateCustomerCommand
            {
                CustomerId = customerResource.Id,
                PhoneNumber = customerResource.PhoneNumber,
                EmailAddress = customerResource.EmailAddress,
                LegacyCustomerId = customerResource.LegacyCustomerId,
                Name = customerResource.Name
            };

            var customerId = await mediator.Send(command,cancellationToken);

            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerId = customerId,
                CustomerIncludes = includesObject
            };

            var results = await mediator.Send(query, cancellationToken);

            return Ok(mapper.Map<CustomerResult, CustomerResult>(results.Single()));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromQuery]Guid id, [FromBody] CustomerResource customerResource, [FromQuery]List<string> includes, CancellationToken cancellationToken)
        {
            var command = new UpdateCustomerCommand()
            {
                CustomerId = id,
                EmailAddress = customerResource.EmailAddress,
                PhoneNumber = customerResource.PhoneNumber,
                Name = customerResource.Name
            };

            await mediator.Send(command,cancellationToken);

            var includesObject = includesMapper.Map<CustomerIncludes>(includes);

            var query = new CustomerQuery
            {
                CustomerId = id,
                CustomerIncludes = includesObject
            };

            var results = await mediator.Send(query, cancellationToken);

            return Ok(mapper.Map<CustomerResult, CustomerResult>(results.Single()));
        }
    }
}
