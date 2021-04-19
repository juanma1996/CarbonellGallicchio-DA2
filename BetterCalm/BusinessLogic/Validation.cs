using System;
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
                throw new NullReferenceException("The object validating is null");
            }
        }
    }
}
