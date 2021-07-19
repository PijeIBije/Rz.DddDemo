using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Rz.DddDemo.Base.Presentation.WebApi.ModelBinding
{
    public class StringEnumerableModelBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (typeof(IEnumerable<string>).IsAssignableFrom(context.Metadata.ModelType)) 
                return new StringEnumerableModelBinder();
            return null;
        }
    }
}
