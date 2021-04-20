using System;
using BusinessExceptions;

namespace BusinessLogic
{
    public class Validation
    {
        public Validation()
        {
        }

        public void Validate<T>(T objectToValidate)
        {
            if (objectToValidate == null)
            {
                throw new NullObjectException("The object validating is null, please check.");
            }
        }
    }
}
