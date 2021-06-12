using System;

namespace BusinessExceptions
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
