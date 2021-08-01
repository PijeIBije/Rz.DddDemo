using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Mapping.Tests.Model;

namespace Rz.DddDemo.Base.Mapping.Tests.DefaultMappings
{
    [TestFixture]
    public abstract class ValueMappingTestsBase
    {
        protected IValueMapping ValueMapping;

        protected IMapper MapperFake;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ValueMapping = SetupValueMapping();
            MapperFake = SetupMapperFake(ValueMapping);
        }

        protected abstract IValueMapping SetupValueMapping();

        protected virtual IMapper SetupMapperFake(IValueMapping testedValueMapping)
        {
            return new Mapper(new IValueMapping[]{testedValueMapping});
        }

        public static IEnumerable<object> TestCases =>
            throw new Exception("Define in inhertited class.");

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void TryMap(TestCase testCase) {
            var success = ValueMapping.TryMap(testCase.SourceValue, testCase.ResultType, out object result,
                testCase.AllowPartialMapping, MapperFake);

            Assert.AreEqual(testCase.Success,success);

            if (testCase.Success)
            {
                Assert.IsTrue(testCase.ValidateResultFunc(result));
            }
        }
    }
}
