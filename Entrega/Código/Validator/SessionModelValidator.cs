using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class SessionModelValidator : IValidator<SessionModel>
    {
        public void Validate(SessionModel sessionModel)
        {
            if (string.IsNullOrEmpty(sessionModel.Email))
                throw new InvalidAttributeException("The email can't be empty");
            if (string.IsNullOrEmpty(sessionModel.Password))
                throw new InvalidAttributeException("The password can't be empty");
        }
    }
}
