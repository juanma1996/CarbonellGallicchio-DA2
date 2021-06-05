using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPlayableContentLogic
    {
        PlayableContent GetById(int playableContentId);
        PlayableContent Create(PlayableContent playableContentModel);
        void DeleteById(int playableContentId);
        void Update(PlayableContent playableContentModel);
        List<PlayableContent> GetByCategoryId(int categoryId);
        List<PlayableContent> GetByPlaylistId(int playlistId);
    }
}