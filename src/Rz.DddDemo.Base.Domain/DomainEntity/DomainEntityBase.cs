using Rz.DddDemo.Base.Domain.DomainEntity.Interfaces;
using Rz.DddDemo.Base.Domain.ValueObject.Interfaces;

namespace Rz.DddDemo.Base.Domain.DomainEntity
{
    public class DomainEntityBase<TId>:SingletonDomainEntityBase, IDomainEntity<TId> where TId:IValueObject
    {
        public TId Id { get; }

        protected DomainEntityBase(TId id)
        {
            Id = id;
        }

        object IDomainEntity.Id => Id;
    }
}
