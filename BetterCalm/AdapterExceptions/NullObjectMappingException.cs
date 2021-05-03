using System;

namespace AdapterExceptions
{
    public class NullObjectMappingException : Exception
    {
        private string errorMessage;

        public NullObjectMappingException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
