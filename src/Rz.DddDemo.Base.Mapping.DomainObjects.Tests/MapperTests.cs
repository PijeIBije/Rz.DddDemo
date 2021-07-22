using NUnit.Framework;
using Rz.DddDemo.Base.Mapping.DefaultMappings;
using Rz.DddDemo.Base.Mapping.DomainObjects.Tests.Model;
using Rz.DddDemo.Base.Mapping.Interface;

namespace Rz.DddDemo.Base.Mapping.DomainObjects.Tests
{
    public class MapperTests
    {
        private IMapper mapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var valueMappings = new IValueMapping[]
            {
                new ObjectToSingleValueObject(),
                new SingleValueToObjectMapping(),
                new DictionaryMapping(),
                new ListMapping(),
                new ClassMapping(),
                new ValueTypeMapping(),
            };

            mapper = new Mapper(valueMappings);
        }

        [Test]
        public void TryMap_SingleValueObjectToObject_Success()
        {
            StringValueObject source = "abc";

            var success = mapper.TryMap<StringValueObject, string>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source.Value,result);
        }

        [Test]
        public void TryMap_ObjectToSingleValueObject_Success()
        {
            string source = "abc";

            var success = mapper.TryMap<string, StringValueObject>(source, out var result);

            Assert.IsTrue(success);
            Assert.AreEqual(source,result.Value);
        }
    }
}
