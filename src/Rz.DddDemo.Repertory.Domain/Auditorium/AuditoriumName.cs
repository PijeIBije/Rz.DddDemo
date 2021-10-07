using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Auditorium
{
    public class AuditoriumName:StringValueObjectBase
    {
        public AuditoriumName(string value) : base(value, 0, 200)
        {
        }
    }
}
