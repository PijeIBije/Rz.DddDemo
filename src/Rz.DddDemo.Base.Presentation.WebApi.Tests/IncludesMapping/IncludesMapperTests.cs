using NUnit.Framework;
using Rz.DddDemo.Base.Presentation.WebApi.IncludesMapping.Interfaces;
using Rz.DddDemo.Base.Presentation.WebApi.Tests.IncludesMapping.Data;

namespace Rz.DddDemo.Base.Presentation.WebApi.Tests.IncludesMapping
{
    [TestFixture]
    public class IncludesMapperTests
    {
        private IIncludesMapper includesMapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            includesMapper = new WebApi.IncludesMapping.IncludesMapper();
        }
        
        [Test]
        public void Map_SimpleIncludesObject_CorrectValuesSet()
        {
            var includes = new[] {"Property2"};

            var includesObject = includesMapper.Map<SimpleIncludesObject>(includes);

            Assert.IsTrue(includesObject.Property2);
            Assert.IsFalse(includesObject.Property1);
        }

        [Test]
        public void Map_NestedIncludesObject_CorrectValuesSet()
        {
            var includes = new[] { "Property3", "Property5.Property1" };

            var includesObject = includesMapper.Map<NestedIncludesObject>(includes);

            Assert.IsTrue(includesObject.Property3);
            Assert.IsFalse(includesObject.Property4);

            Assert.IsTrue(includesObject.Property5.Property1);
            Assert.IsFalse(includesObject.Property5.Property2);
        }
    }
}
