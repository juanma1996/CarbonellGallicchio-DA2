using System;

namespace AdapterExceptions
{
    public class InvalidAttributeException : Exception
    {
        public string errorMessage;
        public InvalidAttributeException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
