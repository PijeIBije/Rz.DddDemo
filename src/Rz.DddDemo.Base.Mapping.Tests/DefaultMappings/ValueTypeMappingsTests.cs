using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Mapping.Tests.Model;

namespace Rz.DddDemo.Base.Mapping.Tests.DefaultMappings
{
    [TestFixture]
    public class ValueTypeMappingsTests:ValueMappingTestsBase
    {

        protected override IValueMapping SetupValueMapping()
        {
            return new ValueTypeMapping();
        }

        public new static IEnumerable<object> TestCases=>

            new object[]
            {
                new TestCase
                {
                    SourceValue = 1,
                    ValidateResultFunc = (result) => (int) result == 1,
                    Success = true,
                    ResultType = typeof(int)
                },
                new TestCase
                {
                    SourceValue = "abc",
                    ValidateResultFunc = (result) => (string) result == "abc",
                    Success = true,
                    ResultType = typeof(string)
                },
                new TestCase
                {
                    SourceValue = 1m,
                    ValidateResultFunc = (result) => (decimal) result == 1m,
                    Success = true,
                    ResultType = typeof(decimal)
                },
                new TestCase
                {
                    SourceValue = 1f,
                    ValidateResultFunc = (result) => (float) result == 1f,
                    Success = true,
                    ResultType = typeof(float)
                    
                },
                new TestCase
                {
                    SourceValue = true,
                    ValidateResultFunc = (result) => (bool) result,
                    Success = true,
                    ResultType = typeof(bool)
                },
            };
    }
}
