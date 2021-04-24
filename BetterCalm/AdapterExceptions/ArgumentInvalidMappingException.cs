using System;

namespace AdapterExceptions
{
    public class ArgumentInvalidMappingException : Exception
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

        public ArgumentInvalidMappingException()
        {
            this.errorMessage = "The object is invalid. Please check.";
        }
        public ArgumentInvalidMappingException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
