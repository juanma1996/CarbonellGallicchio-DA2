using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class AudioContentModelValidator : IValidator<AudioContentModel>
    {
        public void Validate(AudioContentModel audioContentModel)
        {
            if (string.IsNullOrEmpty(audioContentModel.Name))
                throw new InvalidAttributeException("The audio content name can't be empty");
        }
    }
}
