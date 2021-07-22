namespace Rz.DddDemo.Base.Presentation.WebApi.Validation.Errors
{
    public class ValidationError
    {
        public string Name { get; }
        public object Data { get; }
        public string SubPath { get; }

        public ValidationError(string name, object data, string subPath = null)
        {
            Name = name;
            Data = data;
            SubPath = subPath;
        }
    }
}
