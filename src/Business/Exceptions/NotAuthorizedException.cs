using System;

namespace Business.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string message)
            : base(message)
        {

        }
    }
}