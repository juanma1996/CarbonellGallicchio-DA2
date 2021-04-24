using AdapterInterface;
using Model.In;
using Model.Out;
using System;

namespace Adapter
{
    public class AudioContentLogicAdapter : IAudioContentLogicAdapter
    {
        public AudioContentBasicInfoModel GetById(int audioContentId)
        {
            throw new NotImplementedException();
        }
        public AudioContentBasicInfoModel Add(AudioContentModel audioContentModel)
        {
            throw new NotImplementedException();
        }
        public void DeleteById(int audioContentId)
        {
            throw new NotImplementedException();
        }
        public void UpdateById(int audioContentModelId, AudioContentModel audioContentModel)
        {
            throw new NotImplementedException();
        }
    }
}