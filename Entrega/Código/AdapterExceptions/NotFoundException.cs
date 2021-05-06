using System;

namespace AdapterExceptions
{
    public class NotFoundException : Exception
    {
        public string errorMessage;
        public NotFoundException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
