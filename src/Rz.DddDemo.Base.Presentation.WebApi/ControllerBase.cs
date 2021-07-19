using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors;
using Rz.DddDemo.Base.Presentation.WebApi.Validation.Mapping.Interfaces;

namespace Rz.DddDemo.Base.Presentation.WebApi
{
    [ApiController]
    [ProducesResponseType(typeof(Dictionary<string,string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status400BadRequest)]
    public abstract class ControllerBase:Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly HttpContextAccessor httpContextAccessor;
        private readonly IExceptionMapper exceptionMapper;

        private readonly List<GlobalExceptionHandler> globalExceptionHandlers = new List<GlobalExceptionHandler>();

        public IReadOnlyList<GlobalExceptionHandler> GlobalExceptionHandlers => globalExceptionHandlers;

        protected ControllerBase(
            HttpContextAccessor httpContextAccessor,
            IExceptionMapper exceptionMapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.exceptionMapper = exceptionMapper;
        }

        public const string IncludesPropertyPathSeparator = ".";

        public const string IncludesQueryParameterName = ".";

        protected IActionResult NotFound(Exception exception)
        {
            var responseData = new NotFoundError { Message = exception.Message};

            return NotFound(responseData);
        }

        protected IActionResult Created(object id, object resource)
        {
            var uri = GetResourceUri(id);
            return base.Created(uri, resource);
        }

        protected IActionResult BadRequest(Exception exception, params string[] fieldPath)
        {
            var fieldPathString = string.Join('.', fieldPath);

            var validationErrors = exceptionMapper.MapToValidationErrors(exception);

            var responseData = new Dictionary<string,List<ValidationError>> {{fieldPathString,validationErrors.ToList()}};

            return BadRequest(responseData);
        }

        protected Uri GetResourceUri(object id)
        { 
            var absoluteUri = $"{httpContextAccessor.HttpContext.Request.GetDisplayUrl()}/{id}";

            return new Uri(absoluteUri);
        }


        public void AddGlobalExceptionHandler<TException>(Func<TException, bool> predicate,
            Func<TException, IActionResult> hanlder) where TException : Exception
        {
            globalExceptionHandlers.Add(new GlobalExceptionHandler(
                x=>x is TException exception && predicate(exception), x=>hanlder((TException)x)));
        }

        public class GlobalExceptionHandler
        {
            public Func<Exception, bool> Predicate { get; }
            public Func<Exception, IActionResult> Handler { get; }

            public GlobalExceptionHandler(Func<Exception, bool> predicate, Func<Exception, IActionResult> handler)
            {
                Predicate = predicate;
                Handler = handler;
            }
        }
    }
}
