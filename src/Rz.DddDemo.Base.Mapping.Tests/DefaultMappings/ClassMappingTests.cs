using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Base.Mapping.Tests.Model;

namespace Rz.DddDemo.Base.Mapping.Tests.DefaultMappings
{
    public class ClassMappingTests:ValueMappingTestsBase
    {
        public new static IEnumerable<object> TestCases =>
            new object[]
            {
                new TestCase
                {
                    SourceValue = new ClassSameProperties.ValueTypeProperties.Source
                        {
                            A = 1, B= 2m, C = "3"
                        },
                    ValidateResultFunc = (result) =>
                        result is ClassSameProperties.ValueTypeProperties.Result resultCast &&
                        resultCast.A == 1 &&
                        resultCast.B == 2m &&
                        resultCast.C == "3", 
                    Success = true,
                    ResultType = typeof(ClassSameProperties.ValueTypeProperties.Result)
                },
                new TestCase
                {
                    SourceValue = new ClassSameProperties.ComplexProperties.Source
                    {
                        A = new ClassSameProperties.ValueTypeProperties.Source {A = 1, B= 2m, C = "3"},
                        B = new List<ClassSameProperties.ValueTypeProperties.Source> { new ClassSameProperties.ValueTypeProperties.Source { A = 1, B = 2m, C = "3" } },
                        C = new Dictionary<int, ClassSameProperties.ValueTypeProperties.Source>{{1,new ClassSameProperties.ValueTypeProperties.Source { A = 1, B = 2m, C = "3" }}},
                    },
                    ValidateResultFunc = (result) =>
                        result is ClassSameProperties.ComplexProperties.Result resultCast &&
                        resultCast.A.A == 1 &&
                        resultCast.A.B == 2m &&
                        resultCast.A.C == "3" &&
                        resultCast.B.First().A == 1 &&
                        resultCast.B.First().B == 2m &&
                        resultCast.B.First().C == "3" &&
                        resultCast.C[1].A == 1 &&
                        resultCast.C[1].B == 2m &&
                        resultCast.C[1].C == "3",
                    Success = true,
                    ResultType = typeof(ClassSameProperties.ComplexProperties.Result)
                },
                new TestCase
                {
                    SourceValue = new ClassSameProperties.WithConstructor.Source
                    {
                        A = 1, B= 2m, C = "3"
                    },
                    ValidateResultFunc = (result) =>
                        result is ClassSameProperties.WithConstructor.Result resultCast &&
                        resultCast.A == 1 &&
                        resultCast.B == 2m &&
                        resultCast.C == "3",
                    Success = true,
                    ResultType = typeof(ClassSameProperties.WithConstructor.Result)
                },
            };


        protected override IValueMapping SetupValueMapping()
        {
            return new ClassMapping();
        }

        protected override IMapper SetupMapperFake(IValueMapping testedValueMapping)
        {
            return new Mapper(new IValueMapping[]
            {
                new DictionaryMapping(),
                new ListMapping(),
                testedValueMapping,
                new ValueTypeMapping(),
            });
        }
    }
}
