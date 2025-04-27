namespace Shared.ErrorModels
{
    public class ValidationError
    {
        public string FeildName { get; set; }
        public IEnumerable<string> ErrorsMessage { get; set; }
    }
}