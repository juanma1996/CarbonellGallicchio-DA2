using System;

namespace AdapterExceptions
{
    public class AmountOfProblematicsException : Exception
    {
        public string errorMessage;
        public AmountOfProblematicsException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}