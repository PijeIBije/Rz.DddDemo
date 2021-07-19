namespace Rz.DddDemo.Base.Domain.ValueObject.Interfaces
{
    /// <summary>
    /// Generic interface for Value Objects composed of a single value.
    /// </summary>
    /// <typeparam name="TValue">A built in type of the Value Object's actual Value.</typeparam>
    public interface ISingleValueObject<out TValue>:ISingleValueObject
    {
        new TValue Value { get; }
    }

    /// <summary>
    /// Basic interface for Value Objects composed of a single value.
    /// </summary>
    public interface ISingleValueObject:IValueObject
    {
        object Value { get; }
    }
}
