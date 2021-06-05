using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class VideoContentModelValidator : IValidator<VideoContentModel>
    {

        public void Validate(VideoContentModel audioContentModel)
        {
            if (string.IsNullOrEmpty(audioContentModel.Name))
                throw new InvalidAttributeException("The video content name can't be empty");
            if (audioContentModel.Playlists is null)
                throw new InvalidAttributeException("The video content must contain a playlist");
            if (audioContentModel.Categories is null)
                throw new InvalidAttributeException("The video content must contain a category");
        }
    }
}
