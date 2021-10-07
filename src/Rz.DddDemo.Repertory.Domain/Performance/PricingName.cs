using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Performance
{
    public class PricingName:StringValueObjectBase
    {
        public PricingName(string value) : base(value, 0, 200)
        {

        }
    }
}
