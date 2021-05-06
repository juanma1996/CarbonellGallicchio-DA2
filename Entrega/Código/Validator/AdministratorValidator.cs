using BusinessExceptions;
using Domain;
using ValidatorInterface;

namespace Validator
{
    public class AdministratorValidator : IValidator<Administrator>
    {
        public void Validate(Administrator administrator)
        {
            if (administrator is null)
                throw new NullObjectException("There is no administrator registered for the given data");
        }
    }
}