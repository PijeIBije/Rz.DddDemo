using System;
using System.Collections.Generic;
using Rz.DddDemo.Base.Domain.ValueObject.Interfaces;

namespace Rz.DddDemo.Base.Domain.ValueObject
{
    /// <summary>
    /// Base class for Value Objects composed of a single value.
    /// </summary>
    /// <typeparam name="TValue">A built in type of the Value Object's actual Value.</typeparam>
    public class SingleValueObjectBase<TValue>:ISingleValueObject<TValue>, IEquatable<SingleValueObjectBase<TValue>>
    {
        protected SingleValueObjectBase(TValue value)
        {
            Value = value;
        }

        object ISingleValueObject.Value => Value;

        public TValue Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(SingleValueObjectBase<TValue> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() == Value.GetType()) return Value.Equals(obj);
            return Equals((SingleValueObjectBase<TValue>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TValue>.Default.GetHashCode(Value);
        }

        public static bool operator ==(SingleValueObjectBase<TValue> left, SingleValueObjectBase<TValue> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SingleValueObjectBase<TValue> left, SingleValueObjectBase<TValue> right)
        {
            return !Equals(left, right);
        }

        public static implicit operator TValue(SingleValueObjectBase<TValue> valueObject) => valueObject.Value;
    }
}
