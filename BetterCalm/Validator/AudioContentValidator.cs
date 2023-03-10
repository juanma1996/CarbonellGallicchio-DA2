using BusinessExceptions;
using Domain;
using ValidatorInterface;

namespace Validator
{
    public class AudioContentValidator : IValidator<AudioContent>
    {
        public void Validate(AudioContent audioContent)
        {
            if (audioContent is null)
                throw new NullObjectException("Audio content not exist for the given data");
        }
    }
}