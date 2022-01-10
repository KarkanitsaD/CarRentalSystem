using System;

namespace Business.Exceptions
{
    public class InvalidTimeRangeException : Exception
    {
        public InvalidTimeRangeException(string message)
            : base(message)
        {

        }
    }
}