using System;

namespace AdapterExceptions
{
    public class InvalidRouteForImplementationsException : Exception
    {
        public string errorMessage;
        public InvalidRouteForImplementationsException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
