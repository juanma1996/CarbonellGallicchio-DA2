using Domain;

namespace BusinessLogicInterface
{
    public interface IAudioContentLogic
    {
        AudioContent GetById(int audioContentId);
        AudioContent Create(AudioContent audioContentModel);
        void DeleteById(int audioContentId);
        void Update(AudioContent audioContentModel);
    }
}