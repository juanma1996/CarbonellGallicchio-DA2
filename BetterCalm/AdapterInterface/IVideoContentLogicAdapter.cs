using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IVideoContentLogicAdapter
    {
        VideoContentBasicInfoModel GetById(int videoContentId);
        VideoContentBasicInfoModel Add(VideoContentModel videoContentModel);
        void DeleteById(int videoContentId);
        void Update(int id, VideoContentModel videoContentModel);
        List<VideoContentBasicInfoModel> GetByCategoryId(int categoryId);
        List<VideoContentBasicInfoModel> GetByPlaylistId(int playlistId);
        List<VideoContentBasicInfoModel> GetAll();
    }
}
