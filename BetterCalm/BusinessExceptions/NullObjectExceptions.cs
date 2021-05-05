using System;

namespace BusinessExceptions
{
    public class NullObjectException : Exception
    {
        public string errorMessage;
        public NullObjectException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
