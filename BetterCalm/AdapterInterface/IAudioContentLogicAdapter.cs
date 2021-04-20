using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IAudioContentLogicAdapter
    {
        AudioContentBasicInfoModel Get(int audioContentId);
        void Add(AudioContentModel audioContentModel);
    }
}
