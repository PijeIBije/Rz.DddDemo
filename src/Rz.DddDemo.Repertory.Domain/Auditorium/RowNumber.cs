using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Auditorium
{
    public class RowNumber : RangedValueObjectBase<ushort>
    {
        protected RowNumber(ushort value) : base(value, 0, ushort.MaxValue, false, true)
        {

        }
    }
}
