using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterExceptions
{
    public class InvalidNameException : Exception
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
        public InvalidNameException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
