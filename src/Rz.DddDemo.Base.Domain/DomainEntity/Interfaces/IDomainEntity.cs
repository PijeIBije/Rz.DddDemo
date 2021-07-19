using Rz.DddDemo.Base.Domain.ValueObject.Interfaces;

namespace Rz.DddDemo.Base.Domain.DomainEntity.Interfaces
{
    public interface IDomainEntity<out TId>: IDomainEntity where TId:IValueObject
    {
        new TId Id { get; }
    }

    public interface IDomainEntity
    {
        object Id { get; }
    }
}
