namespace MotoFlow.Application.Commom.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException(string message) : base(message)
        {
            
        }
    }
}
