namespace Rz.DddDemo.Base.Mapping.Tests.Model
{
    public static class ClassWithExtraProperties
    {
        public class Source: ClassSameProperties.ValueTypeProperties.Source
        {
            public bool D { get; set; }
        }

        public class Result : ClassSameProperties.ValueTypeProperties.Result
        {
        }
    }
}
