using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IAudioContentLogicAdapter
    {
        AudioContentBasicInfoModel GetById(int audioContentId);
        AudioContentBasicInfoModel Add(AudioContentModel audioContentModel);
        void DeleteById(int audioContentId);
        void Update(AudioContentModel audioContentModel);
    }
}
