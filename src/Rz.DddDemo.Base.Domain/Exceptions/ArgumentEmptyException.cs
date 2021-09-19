using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Base.Domain.Exceptions
{
    public class ArgumentEmptyException:ArgumentException
    {
        public ArgumentEmptyException(string message, string paramName):base(message,paramName)
        {
            
        }
    }
}
