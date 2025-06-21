namespace UniversidadQ10.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string msg) : base(msg)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
