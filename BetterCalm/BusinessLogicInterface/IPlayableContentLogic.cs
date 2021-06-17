using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPlayableContentLogic
    {
        PlayableContent GetById(int playableContentId);
        PlayableContent Create(PlayableContent playableContentModel);
        void DeleteById(int playableContentId);
        void Update(int id, PlayableContent playableContentModel);
        List<PlayableContent> GetByCategoryId(int categoryId, int playableContentTypeId);
        List<PlayableContent> GetByPlaylistId(int playlistId, int playableContentTypeId);
        List<PlayableContent> GetAll(int playableContentTypeId);
    }
}