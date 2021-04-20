using Model.Out;

namespace AdapterInterface
{
    public interface IAudioContentLogicAdapter
    {
        AudioContentBasicInfoModel Get(int audioContentId);
    }
}
