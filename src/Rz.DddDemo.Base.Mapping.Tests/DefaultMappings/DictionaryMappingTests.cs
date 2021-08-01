using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Mapping.Tests.Model;

namespace Rz.DddDemo.Base.Mapping.Tests.DefaultMappings
{
    public class DictionaryMappingTests : ValueMappingTestsBase
    {
        public new static IEnumerable<object> TestCases =>
            new object[]
            {
                new TestCase
                {
                    SourceValue = new Dictionary<int,string> {{1,"a"},{2,"b"},{3,"c"}},
                    ValidateResultFunc = (result) =>
                        result is Dictionary<int,string> resultAsDictionary &&
                        resultAsDictionary.ContainsKey(1) &&
                        resultAsDictionary.ContainsKey(2) &&
                        resultAsDictionary.ContainsKey(3) &&
                        resultAsDictionary[1] == "a" &&
                        resultAsDictionary[2] == "b" &&
                        resultAsDictionary[3] == "c",
                    Success = true,
                    ResultType = typeof(Dictionary<int,string>)
                },
            };


        protected override IValueMapping SetupValueMapping()
        {
            return new DictionaryMapping();
        }

        protected override IMapper SetupMapperFake(IValueMapping testedValueMapping)
        {
            return new Mapper(new IValueMapping[]
            {
                testedValueMapping,
                new ListMapping(), 
                new ClassMapping(),
                new ValueTypeMapping(),
            });
        }
    }
}
