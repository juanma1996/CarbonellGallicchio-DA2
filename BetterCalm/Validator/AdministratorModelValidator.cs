using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class AdministratorModelValidator : IValidator<AdministratorModel>
    {
        public void Validate(AdministratorModel administratorModel)
        {
            if (string.IsNullOrEmpty(administratorModel.Name))
                throw new InvalidAttributeException("The administrator name can't be empty");
            if (string.IsNullOrEmpty(administratorModel.Password))
                throw new InvalidAttributeException("The administrator password can't be empty");
        }
    }
}
