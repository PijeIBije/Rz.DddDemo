using System;

namespace Rz.DddDemo.Base.Infrastructure.Exceptions
{
    public class NoResultsException:Exception
    {
        public Type EntityType { get; }
        public object Id { get; }

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
            EntityType = entityType;
            Id = id;
        }
    }
}
