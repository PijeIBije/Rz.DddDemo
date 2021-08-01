using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Base.Mapping.Tests.Model
{
    public class TestCase
    {
        public object SourceValue { get; set; }

        public Func<object, bool> ValidateResultFunc { get; set; }

        public bool Success { get; set; }

        public Type ResultType { get; set; }

        public bool AllowPartialMapping { get; set; }
    }
}
