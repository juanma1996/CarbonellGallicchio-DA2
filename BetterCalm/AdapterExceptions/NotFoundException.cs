using System;

namespace AdapterExceptions
{
    public class NotFoundException : Exception
    {
        private string errorMessage;
        public NotFoundException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
