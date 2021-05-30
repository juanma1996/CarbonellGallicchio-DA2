using Model.Out;

namespace AdapterInterface
{
    public interface IVideoContentLogicAdapter
    {
        VideoContentBasicInfoModel GetById(int videoContentId);
    }
}
