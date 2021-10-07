using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Play
{
    public class PlayId:GuidValueObjectBase
    {
        public PlayId(Guid value) : base(value)
        {

        }

        public PlayId()
        {

        }

        public static implicit operator PlayId(Guid value) => new PlayId(value);
    }
}
