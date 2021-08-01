using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Mapping.Tests.Model;

namespace Rz.DddDemo.Base.Mapping.Tests.DefaultMappings
{
    public class ListMappingTests:ValueMappingTestsBase
    {
        public new static IEnumerable<object> TestCases =>
            new object[]
            {
                new TestCase
                {
                    SourceValue = new List<int> {1,2,3},
                    ValidateResultFunc = (result) => 
                        result is List<int> resultAsList && 
                        resultAsList.Contains(1) && 
                        resultAsList.Contains(2) && 
                        resultAsList.Contains(3) ,
                    Success = true,
                    ResultType = typeof(List<int>)
                },
            };
    

    protected override IValueMapping SetupValueMapping()
        {
            return new ListMapping();
        }

        protected override IMapper SetupMapperFake(IValueMapping testedValueMapping)
        {
            return new Mapper(new IValueMapping[]
            {
                new DictionaryMapping(), 
                testedValueMapping, 
                new ClassMapping(), 
                new ValueTypeMapping(), 
            });
        }
    }
}
