using System;

namespace BusinessExceptions
{
    public class NullObjectException : Exception
    {
        private string errorMessage;
        public NullObjectException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
