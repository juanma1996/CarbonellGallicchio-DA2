using BusinessExceptions;
using Domain;
using ValidatorInterface;

namespace Validator
{
    public class PsychologistValidator : IValidator<Psychologist>
    {
        public void Validate(Psychologist psychologist)
        {
            if (psychologist is null)
                throw new NullObjectException("There is no psychologist registered for the given data");
        }
    }
}
