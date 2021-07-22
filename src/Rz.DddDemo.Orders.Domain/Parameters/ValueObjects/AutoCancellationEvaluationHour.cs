﻿using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Orders.Domain.Parameters.ValueObjects
{
    public class AutoCancellationHour : RangedValueObjectBase<int>
    {
        public const int Min = 0;
        public const int Max = 23;

        protected AutoCancellationHour(int value) : base(value, Min, Max, true, true)
        {

        }
    }
}
