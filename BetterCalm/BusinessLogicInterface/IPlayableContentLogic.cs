using Domain;

namespace BusinessLogicInterface
{
    public interface IPlayableContentLogic
    {
        PlayableContent GetById(int playableContentId);
        PlayableContent Create(PlayableContent playableContentModel);
        void DeleteById(int playableContentId);
        void Update(PlayableContent playableContentModel);
    }
}