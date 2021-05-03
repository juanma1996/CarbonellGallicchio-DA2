using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class PlaylistModelValidator : IValidator<PlaylistModel>
    {
        public void Validate(PlaylistModel playlistModel)
        {
            if (string.IsNullOrEmpty(playlistModel.Name))
                throw new InvalidAttributeException("The playlist name can't be empty");
        }
    }
}
