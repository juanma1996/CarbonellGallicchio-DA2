using System;
namespace AdapterExceptions
{
    public class AmountOfProblematicsException : Exception
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

        public AmountOfProblematicsException()
        {
            this.errorMessage = "The amount of problematics is invalid. It's have to be four, please check.";
        }
        
        public AmountOfProblematicsException(String msg)
        {
            this.errorMessage = msg;
        }
    }
}
