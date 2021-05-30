using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IVideoContentLogicAdapter
    {
        VideoContentBasicInfoModel GetById(int videoContentId);
        VideoContentBasicInfoModel Add(VideoContentModel videoContentModel);
        void DeleteById(int videoContentId);
    }
}
