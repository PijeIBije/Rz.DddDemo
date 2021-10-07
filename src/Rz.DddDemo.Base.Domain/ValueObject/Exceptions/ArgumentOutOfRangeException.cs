namespace Rz.DddDemo.Base.Domain.ValueObject.Exceptions
{
    public class ArgumentOutOfRangeException<TValue> : System.ArgumentOutOfRangeException
    {
        public TValue ValueMin { get; }
        public TValue ValueMax { get; }
        public bool IncludeMin { get; }
        public bool IncludeMax { get; }

        public ArgumentOutOfRangeException(
            string parameterName, 
            TValue actualValue, 
            TValue valueMin, 
            TValue valueMax, 
            bool includeMin, 
            bool includeMax, 
            string messae = null):base(parameterName,actualValue,messae)
        {
            ValueMin = valueMin;
            ValueMax = valueMax;
            IncludeMin = includeMin;
            IncludeMax = includeMax;
        }
    }
}
