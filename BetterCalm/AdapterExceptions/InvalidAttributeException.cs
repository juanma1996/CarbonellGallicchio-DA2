using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterExceptions
{
    public class InvalidAttributeException : Exception
    {
        private string errorMessage;
        public InvalidAttributeException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
