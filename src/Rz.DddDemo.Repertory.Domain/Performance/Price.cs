using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Performance
{
    public class Price : RangedValueObjectBase<decimal>
    {
        protected Price(decimal value) : base(value, 0, decimal.MaxValue, false, true)
        {
        }

        public static implicit operator Price(decimal value) => new Price(value);
    }
}
