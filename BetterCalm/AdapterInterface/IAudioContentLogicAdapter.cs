using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IAudioContentLogicAdapter
    {
        AudioContentBasicInfoModel GetById(int audioContentId);
        AudioContentBasicInfoModel Add(AudioContentModel audioContentModel);
        void DeleteById(int audioContentId);
        void Update(int id, AudioContentModel audioContentModel);
        List<AudioContentBasicInfoModel> GetByCategoryId(int categoryId);
        List<AudioContentBasicInfoModel> GetByPlaylistId(int playlistId);
        List<AudioContentBasicInfoModel> GetAll();
    }
}
