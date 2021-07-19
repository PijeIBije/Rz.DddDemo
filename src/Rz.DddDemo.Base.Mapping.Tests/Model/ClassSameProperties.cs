using System.Collections.Generic;

namespace Rz.DddDemo.Base.Mapping.Tests.Model
{
    public static class ClassSameProperties
    {
        public static class ValueTypeProperties
        {
            public class Source
            {
                public int A { get; set; }

                public decimal B { get; set; }

                public string C { get; set; }
            }

            public class Result
            {
                public int A { get; set; }

                public decimal B { get; set; }

                public string C { get; set; }
            }
        }

        public static class ComplexProperties
        {
            public class Source
            {
                public Dictionary<int,ValueTypeProperties.Source> C { get; set; }

                public List<ValueTypeProperties.Source> B { get; set; }

                public ValueTypeProperties.Source A { get; set; }
            }

            public class Result
            {
                public Dictionary<int, ValueTypeProperties.Result> C { get; set; }

                public List<ValueTypeProperties.Result> B { get; set; }

                public ValueTypeProperties.Result A { get; set; }
            }
        }

        public static class WithConstructor
        {
            public class Source
            {
                public int A { get; set; }

                public decimal B { get; set; }

                public string C { get; set; }
            }

            public class Result
            {
                public Result(decimal b, int a, string c)
                {
                    B = b;
                    A = a;
                    C = c;
                }

                public int A { get; }

                public decimal B { get; }

                public string C { get; }
            }
        }
    }
}
