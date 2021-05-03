using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterExceptions
{
    public class InvalidAttributeException : Exception
    {
        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            private set
            {
                this.errorMessage = value;
            }
        }
        public InvalidAttributeException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
