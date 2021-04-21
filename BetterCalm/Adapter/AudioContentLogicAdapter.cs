using AdapterInterface;
using Model.In;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    public class AudioContentLogicAdapter : IAudioContentLogicAdapter
    {
        public AudioContentBasicInfoModel Get(int audioContentId)
        {
            throw new NotImplementedException();
        }
        public AudioContentBasicInfoModel Add(AudioContentModel audioContentModel)
        {
            throw new NotImplementedException();
        }
        public void Delete(int audioContentId)
        {
            throw new NotImplementedException();
        }
    }
}