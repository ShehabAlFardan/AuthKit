namespace AuthKit.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string Title { get; }
        public string Detail { get; }
        public string Code { get; }

        public DomainException(string title, string detail, string code = null)
        {
            Title = title;
            Detail = detail;
            Code = code;
        }
    }
}
