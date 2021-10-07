using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class PurchaseId : GuidValueObjectBase
    {
        public PurchaseId()
        {

        }

        public PurchaseId(Guid guid) : base(guid)
        {

        }

        public static implicit operator PurchaseId(Guid guid) => new PurchaseId(guid);
    }
}
