using System;

namespace BusinessExceptions
{
    public class NullObjectException : Exception
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

        public NullObjectException()
        {
            this.errorMessage = "Null object appeared. Please check.";
        }
        public NullObjectException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
