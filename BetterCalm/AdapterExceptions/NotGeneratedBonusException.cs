using System;

namespace AdapterExceptions
{
    public class NotGeneratedBonusException : Exception
    {
        public string errorMessage;
        public NotGeneratedBonusException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}
