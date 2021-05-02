using System;
using System.Collections.Generic;
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

        public void ValidateList<T>(List<T> objectToValidate)
        {
            if (objectToValidate == null || objectToValidate.Count == 0)
            {
                throw new NullObjectException("The object validating has not elements, please check.");
            }
        }

        public void NullObjectException()
        {
            throw new NullObjectException();
        }
    }
}
