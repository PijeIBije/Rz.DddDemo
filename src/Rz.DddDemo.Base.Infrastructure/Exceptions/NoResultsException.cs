using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Base.Infrastructure.Exceptions
{
    public class NoResultsException:Exception
    {
        public NoResultsException()
        {
            
        }

        public NoResultsException(string message):base(message)
        {
            
        }

        public NoResultsException(string message,Exception innerException):base(message,innerException)
        {
            
        }

        public NoResultsException(Type entityType, object id) : this($"No entity {entityType.Name} with id {id}")
        {

        }
    }
}
