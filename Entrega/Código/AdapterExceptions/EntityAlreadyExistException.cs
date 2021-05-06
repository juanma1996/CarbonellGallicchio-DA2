using System;

namespace AdapterExceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public string errorMessage;
        public EntityAlreadyExistException(string msg)
        {
            this.errorMessage = msg;
        }
    }
}