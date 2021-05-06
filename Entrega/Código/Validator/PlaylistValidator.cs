using BusinessExceptions;
using Domain;
using ValidatorInterface;

namespace Validator
{
    public class PlaylistValidator : IValidator<Playlist>
    {
        public void Validate(Playlist playlist)
        {
            if (playlist is null)
                throw new NullObjectException("Playlist not exist for the given data");
        }
    }
}
