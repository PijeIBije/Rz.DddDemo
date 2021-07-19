using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.Interface;
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

        [Test]
        public void TryMap_Null_Success()
        {
            string source = null;

            var success = mapper.TryMap<string, string>(source, out var result);

            Assert.IsTrue(success);
            Assert.IsNull(result);
        }

        [Test]
        public void TryMap_ValueTypes_Success()
        {
            var source = "abc";

            var success = mapper.TryMap<string, string>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source,result);
        }

        [Test]
        public void TryMap_ListOfValueTypes_Success()
        {
            var source = new List<string> {"abc", "cde"};

            var success = mapper.TryMap<List<string>, List<string>>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source[0], result[0]);
            Assert.AreEqual(source[1], result[1]);
        }

        [Test]
        public void TryMap_DictionariesOfValueTypes_Success()
        {
            var source = new Dictionary<string,int> { {"abc",1}, {"cde",2} };

            var success = mapper.TryMap<Dictionary<string, int>, Dictionary<string, int>>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source.Keys.ToArray()[0], result.Keys.ToArray()[0]);
            Assert.AreEqual(source.Values.ToArray()[0], result.Values.ToArray()[0]);
            Assert.AreEqual(source.Keys.ToArray()[1], result.Keys.ToArray()[1]);
            Assert.AreEqual(source.Values.ToArray()[1], result.Values.ToArray()[1]);
        }

        [Test]
        public void TryMap_ClassesWithSameValueTypeProperties_Success()
        {
            var source = new ClassSameProperties.ValueTypeProperties.Source
            {
                A = 1,
                B = 2m, 
                C = "abc"
            };

            var success = mapper.TryMap<ClassSameProperties.ValueTypeProperties.Source, ClassSameProperties.ValueTypeProperties.Source>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source.A, result.A);
            Assert.AreEqual(source.B, result.B);
            Assert.AreEqual(source.C, result.C);
        }

        [Test]
        public void TryMap_ClassesWithSameComplexProperties_Success()
        {
            var source = new ClassSameProperties.ComplexProperties.Source
            {
                A = new ClassSameProperties.ValueTypeProperties.Source
                {
                    A = 1,
                    B = 2m,
                    C = "abc",
                },
                B = new List<ClassSameProperties.ValueTypeProperties.Source>
                {
                    new ClassSameProperties.ValueTypeProperties.Source 
                    {
                        A = 1,
                        B = 2m,
                        C = "abc",
                    }
                },
                C = new Dictionary<int, ClassSameProperties.ValueTypeProperties.Source>
                {
                    {
                        1, new ClassSameProperties.ValueTypeProperties.Source
                        {
                            A = 1,
                            B = 2m,
                            C = "abc",
                        }
                    }
                }
            };

            var success = mapper.TryMap<ClassSameProperties.ComplexProperties.Source, ClassSameProperties.ComplexProperties.Source>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source.A.A, result.A.A);
            Assert.AreEqual(source.A.B, result.A.B);
            Assert.AreEqual(source.A.C, result.A.C);

            Assert.AreEqual(source.B[0].A, result.B[0].A);
            Assert.AreEqual(source.B[0].B, result.B[0].B);
            Assert.AreEqual(source.B[0].C, result.B[0].C);

            Assert.AreEqual(source.C[1].A, result.C[1].A);
            Assert.AreEqual(source.C[1].B, result.C[1].B);
            Assert.AreEqual(source.C[1].C, result.C[1].C);
        }

        [Test]
        public void TryMap_ClassesWithSamePropertiesWithConstrucor_Success()
        {
            var source = new ClassSameProperties.WithConstructor.Source
            {
                A = 1,
                B = 2m,
                C = "abc"
            };

            var success = mapper.TryMap<ClassSameProperties.WithConstructor.Source, ClassSameProperties.WithConstructor.Source>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source.A, result.A);
            Assert.AreEqual(source.B, result.B);
            Assert.AreEqual(source.C, result.C);
        }
    }
}
