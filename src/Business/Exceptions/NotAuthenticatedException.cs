using System;

namespace Business.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string message)
            :base(message)
        {
        }
    }
}