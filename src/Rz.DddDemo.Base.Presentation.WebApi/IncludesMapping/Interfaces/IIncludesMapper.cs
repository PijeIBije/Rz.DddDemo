using System.Collections.Generic;

namespace Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping.Interfaces
{
    public interface IIncludesMapper
    {
        T Map<T>(IEnumerable<string> includes) where T : class;
    }
}