using System;

namespace AdapterExceptions
{
    public class NullObjectMappingException : Exception
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

        public NullObjectMappingException()
        {
            this.errorMessage = "The object intenting to map is null. Please check.";
        }
        public NullObjectMappingException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
