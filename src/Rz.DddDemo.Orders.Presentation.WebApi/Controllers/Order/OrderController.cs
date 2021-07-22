﻿using Microsoft.AspNetCore.Http;
using Rz.DddDemo.Base.Presentation.WebApi;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;

namespace Rz.DddDemo.Orders.Presentation.WebApi.Controllers.Order
{
    public class OrderController:ControllerBase
    {
        public OrderController(
            HttpContextAccessor httpContextAccessor, 
            IExceptionMapper exceptionMapper) : base(httpContextAccessor, exceptionMapper)
        {
        }
    }
}
