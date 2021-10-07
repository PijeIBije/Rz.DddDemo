using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Play
{
    public class PlayName:StringValueObjectBase
    {
        public PlayName(string value) : base(value, 0, 200)
        {
        }
    }
}
