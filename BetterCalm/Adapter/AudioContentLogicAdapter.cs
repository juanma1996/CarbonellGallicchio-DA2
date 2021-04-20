using AdapterInterface;
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
    }
}
