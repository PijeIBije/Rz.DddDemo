using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Repertory.Domain.Auditorium
{
    public class AuditioriumId:GuidValueObjectBase
    {
        public AuditioriumId(Guid value) : base(value)
        {
            
        }

        public AuditioriumId()
        {
            
        }
    }
}
