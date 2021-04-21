using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IAudioContentLogicAdapter
    {
        AudioContentBasicInfoModel Get(int audioContentId);
        AudioContentBasicInfoModel Add(AudioContentModel audioContentModel);
        void Delete(int audioContentId);
        void Update(int v, AudioContentModel audioContentModel);
    }
}
