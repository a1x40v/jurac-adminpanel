namespace Application.Common.Exceptions
{
    public class ExternalResourceException : Exception
    {
        public ExternalResourceException()
            : base()
        {
        }

        public ExternalResourceException(string message)
            : base(message)
        {
        }
    }
}