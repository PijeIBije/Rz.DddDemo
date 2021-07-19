using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Rz.DddDemo.Base.Presentation.WebApi.ModelBinding
{
    public class StringEnumerableModelBinder : IModelBinder
    {
        public const char Separator = ',';

        public Task BindModelAsync(ModelBindingContext bindingContext)
        { 
            if(bindingContext == null) throw new Exception($"{nameof(bindingContext)} is null");

            if (typeof(IEnumerable<string>).IsAssignableFrom(bindingContext.ModelType))
            {
                var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

                var result = new List<string>();

                foreach (var value in valueResult.Values)
                {
                    var values = value.Split(Separator).Where(x => !string.IsNullOrWhiteSpace(x));

                    result.AddRange(values);
                }

                if (!result.Any()) result = null;

                bindingContext.Result = ModelBindingResult.Success(result);

                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Failed();

            return Task.CompletedTask;
        }
    }
}