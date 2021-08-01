using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Mapping.Tests.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Tests.Model;

namespace Rz.DddDemo.Base.Mapping.Tests
{
    [TestFixture]
    public class MapperTests
    {
        private IMapper mapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var valueMappings = new IValueMapping[]
            {
                new DictionaryMapping(),
                new ListMapping(),
                new ClassMapping(),
                new ValueTypeMapping(),
            };

            mapper = new Mapping.Mapper(valueMappings);
        }

        public static IEnumerable<object> TestCases =>
            ClassMappingTests.TestCases.Union(
                ListMappingTests.TestCases.Union(
                    ValueTypeMappingsTests.TestCases.Union(
                        DictionaryMappingTests.TestCases).Union(
                        new[]
                        {
                            new TestCase
                            {
                                ResultType = null,
                                Success = true,
                                ValidateResultFunc = x => x == null,
                                SourceValue = null
                            }
                        })));

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void TryMap(TestCase testCase)
        {
            var success = mapper.TryMap(testCase.SourceValue, out object result, testCase.ResultType,
                testCase.AllowPartialMapping);

            Assert.AreEqual(testCase.Success, success);

            if (testCase.Success)
            {
                Assert.IsTrue(testCase.ValidateResultFunc(result));
            }
        }
    }
}
