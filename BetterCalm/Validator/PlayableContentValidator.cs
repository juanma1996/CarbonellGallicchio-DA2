using BusinessExceptions;
using Domain;
using ValidatorInterface;

namespace Validator
{
    public class PlayableContentValidator : IValidator<PlayableContent>
    {
        public void Validate(PlayableContent playableContent)
        {
            if (playableContent is null)
                throw new NullObjectException("Audio content not exist for the given data");
        }
    }
}