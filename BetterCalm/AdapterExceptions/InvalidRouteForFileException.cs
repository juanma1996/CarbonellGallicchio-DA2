using System;

namespace AdapterExceptions
{
    public class InvalidRouteForFileException : Exception
    {
        public string errorMessage;
        public InvalidRouteForFileException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
